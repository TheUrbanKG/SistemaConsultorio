using System;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SistemaConsultorio.Logica
{
    public enum FingerprintMode
    {
        LoginPersonal,      // Para login del personal
        BusquedaPaciente,   // Para buscar pacientes
        RegistroUsuario,    // Para registrar en frmCuentas
        RegistroPaciente    // Para registrar pacientes
    }

    public class FingerprintManager
    {
        private SerialPort serialPort;
        private string connectionString;
        private bool isConnected = false;

        // Comandos reales para el FPM10A
        private readonly byte[] CMD_GET_IMAGE = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x01, 0x00, 0x05 };
        private readonly byte[] CMD_GENERATE_TEMPLATE = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x02, 0x00, 0x06 };
        private readonly byte[] CMD_SEARCH_FINGERPRINT = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x08, 0x04, 0x01, 0x00, 0x00, 0x00, 0x64, 0x00, 0x73 };
        private readonly byte[] CMD_CREATE_TEMPLATE = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x05, 0x00, 0x09 };
        private readonly byte[] CMD_STORE_TEMPLATE = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x06, 0x06, 0x01, 0x00, 0x01, 0x00, 0x0E };

        // Estados del proceso
        private enum ProcessState { Idle, Capturing, Generating, Searching, Storing }
        private ProcessState currentState = ProcessState.Idle;
        private FingerprintMode currentMode;
        private byte[] currentTemplate;

        // Eventos
        public event Action<string> OnStatusChanged;
        public event Action<bool, string, string> OnAuthenticationResult; // éxito, usuario, nombre
        public event Action<string, int, string> OnPacienteEncontrado; // nombre, pacienteID, cédula
        public event Action OnHuellaCapturada; // Para registro
        public event Action<bool, string> OnRegistrationResult; // éxito, mensaje

        public FingerprintManager()
        {
            this.connectionString = "Server=.;Database=tesis;Integrated Security=true;";
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.ErrorReceived += SerialPort_ErrorReceived;
        }

        public bool Connect(string portName = "COM3", int baudRate = 57600)
        {
            try
            {
                if (isConnected) Disconnect();

                // Verificar que el puerto existe
                var availablePorts = SerialPort.GetPortNames();
                if (!availablePorts.Contains(portName))
                {
                    OnStatusChanged?.Invoke($"Puerto {portName} no encontrado. Puertos disponibles: {string.Join(", ", availablePorts)}");
                    return false;
                }

                serialPort.PortName = portName;
                serialPort.BaudRate = baudRate;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.Handshake = Handshake.None;
                serialPort.ReadTimeout = 5000;
                serialPort.WriteTimeout = 5000;

                serialPort.Open();
                isConnected = true;

                OnStatusChanged?.Invoke($"Lector de huellas conectado correctamente en {portName}");
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                OnStatusChanged?.Invoke($"Error: Puerto {portName} está en uso por otra aplicación");
                return false;
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error al conectar en {portName}: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (serialPort?.IsOpen == true)
                {
                    serialPort.Close();
                }
                isConnected = false;
                currentState = ProcessState.Idle;
                OnStatusChanged?.Invoke("Lector desconectado");
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error al desconectar: {ex.Message}");
            }
        }

        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            OnStatusChanged?.Invoke($"Error de comunicación: {e.EventType}");
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(100); // Pequeña pausa para recibir todos los datos

                int bytesToRead = serialPort.BytesToRead;
                if (bytesToRead == 0) return;

                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                ProcessFingerprintResponse(buffer);
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error recibiendo datos: {ex.Message}");
            }
        }

        private void ProcessFingerprintResponse(byte[] response)
        {
            if (response.Length < 12)
            {
                OnStatusChanged?.Invoke("Respuesta demasiado corta del sensor");
                return;
            }

            // Verificar el header del paquete (0xEF 0x01)
            if (response[0] == 0xEF && response[1] == 0x01)
            {
                byte confirmationCode = response[9]; // El código de confirmación está en la posición 9

                switch (confirmationCode)
                {
                    case 0x00: // Éxito
                        HandleSuccessResponse(response);
                        break;

                    case 0x01:
                        OnStatusChanged?.Invoke("Error al recibir paquete");
                        break;
                    case 0x02:
                        OnStatusChanged?.Invoke("No hay dedo en el sensor");
                        break;
                    case 0x03:
                        OnStatusChanged?.Invoke("Error al tomar imagen de huella");
                        break;
                    case 0x06:
                        OnStatusChanged?.Invoke("Error al generar template - características insuficientes");
                        break;
                    case 0x07:
                        OnStatusChanged?.Invoke("Error al comparar huellas");
                        break;
                    case 0x08:
                        OnStatusChanged?.Invoke("No se encontró huella coincidente");
                        HandleNoMatchFound();
                        break;
                    case 0x09:
                        OnStatusChanged?.Invoke("No se encontraron características de huella");
                        break;
                    case 0x0A:
                        OnStatusChanged?.Invoke("Error al cancelar comando");
                        break;
                    case 0x0B:
                        OnStatusChanged?.Invoke("Error al almacenar huella");
                        break;
                    case 0x0C:
                        OnStatusChanged?.Invoke("Posición de almacenamiento inválida");
                        break;
                    case 0x0D:
                        OnStatusChanged?.Invoke("La posición ya contiene una huella");
                        break;

                    default:
                        OnStatusChanged?.Invoke($"Respuesta desconocida del sensor: 0x{confirmationCode:X2}");
                        break;
                }
            }
            else
            {
                OnStatusChanged?.Invoke("Header de respuesta inválido");
            }
        }

        private void HandleSuccessResponse(byte[] response)
        {
            switch (currentState)
            {
                case ProcessState.Capturing:
                    OnStatusChanged?.Invoke("Imagen capturada correctamente. Generando template...");
                    currentState = ProcessState.Generating;
                    SendCommand(CMD_GENERATE_TEMPLATE);
                    break;

                case ProcessState.Generating:
                    OnStatusChanged?.Invoke("Template generado. Procesando...");

                    // Extraer template
                    if (response.Length >= 12)
                    {
                        currentTemplate = new byte[response.Length - 12];
                        Array.Copy(response, 12, currentTemplate, 0, currentTemplate.Length);

                        // Diferente acción según el modo
                        switch (currentMode)
                        {
                            case FingerprintMode.LoginPersonal:
                                AuthenticatePersonal(currentTemplate);
                                break;
                            case FingerprintMode.BusquedaPaciente:
                                SearchPaciente(currentTemplate);
                                break;
                            case FingerprintMode.RegistroUsuario:
                            case FingerprintMode.RegistroPaciente:
                                OnHuellaCapturada?.Invoke();
                                OnStatusChanged?.Invoke("Huella capturada lista para registrar");
                                break;
                        }
                    }
                    currentState = ProcessState.Idle;
                    break;

                case ProcessState.Searching:
                    // Procesar resultado de búsqueda en sensor (si se usa)
                    if (response.Length >= 16)
                    {
                        int pageID = response[10] * 256 + response[11];
                        int matchScore = response[12] * 256 + response[13];

                        if (pageID > 0)
                        {
                            OnStatusChanged?.Invoke($"Huella encontrada en sensor (ID: {pageID}, Score: {matchScore})");
                        }
                    }
                    currentState = ProcessState.Idle;
                    break;

                case ProcessState.Storing:
                    OnStatusChanged?.Invoke("Huella almacenada exitosamente en el sensor");
                    OnRegistrationResult?.Invoke(true, "Huella registrada exitosamente");
                    currentState = ProcessState.Idle;
                    break;

                default:
                    OnStatusChanged?.Invoke("Comando ejecutado correctamente");
                    break;
            }
        }

        private void HandleNoMatchFound()
        {
            switch (currentMode)
            {
                case FingerprintMode.LoginPersonal:
                    OnAuthenticationResult?.Invoke(false, null, null);
                    break;
                case FingerprintMode.BusquedaPaciente:
                    OnPacienteEncontrado?.Invoke(null, 0, null);
                    break;
            }
        }

        // Métodos públicos para el control del sensor
        // Métodos públicos para el control del sensor
        public void StartCapture(FingerprintMode mode)
        {
            if (!isConnected)
            {
                OnStatusChanged?.Invoke("Conecte el lector primero");
                return;
            }

            currentMode = mode;

            try
            {
                currentState = ProcessState.Capturing;
                SendCommand(CMD_GET_IMAGE);

                string mensaje;
                switch (mode)
                {
                    case FingerprintMode.LoginPersonal:
                        mensaje = "Coloque su dedo para ingresar al sistema...";
                        break;
                    case FingerprintMode.BusquedaPaciente:
                        mensaje = "Coloque el dedo del paciente para buscar...";
                        break;
                    case FingerprintMode.RegistroUsuario:
                        mensaje = "Coloque su dedo para registrar...";
                        break;
                    case FingerprintMode.RegistroPaciente:
                        mensaje = "Coloque el dedo del paciente para registrar...";
                        break;
                    default:
                        mensaje = "Coloque su dedo en el sensor...";
                        break;
                }

                OnStatusChanged?.Invoke(mensaje);
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error iniciando captura: {ex.Message}");
                currentState = ProcessState.Idle;
            }
        }

        // Método legacy para compatibilidad
        public void StartAuthentication()
        {
            StartCapture(FingerprintMode.LoginPersonal);
        }

        private void SendCommand(byte[] command)
        {
            if (!isConnected) return;

            try
            {
                serialPort.Write(command, 0, command.Length);
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error enviando comando: {ex.Message}");
                currentState = ProcessState.Idle;
            }
        }

        // Métodos de autenticación y búsqueda
        private void AuthenticatePersonal(byte[] template)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "SELECT Usuario, Nombre, Apellido, Rol FROM login WHERE FingerprintTemplate = @template AND Status = 'Habilitado'",
                        connection);

                    command.Parameters.AddWithValue("@template", template);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string usuario = reader["Usuario"].ToString();
                            string nombre = reader["Nombre"].ToString();
                            string apellido = reader["Apellido"].ToString();
                            string rol = reader["Rol"].ToString();

                            string nombreCompleto = $"{nombre} {apellido}";

                            OnAuthenticationResult?.Invoke(true, usuario, nombreCompleto);
                            OnStatusChanged?.Invoke($"Autenticación exitosa: {nombreCompleto} ({rol})");
                        }
                        else
                        {
                            OnAuthenticationResult?.Invoke(false, null, null);
                            OnStatusChanged?.Invoke("Huella no registrada en el sistema");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error consultando base de datos: {ex.Message}");
                OnAuthenticationResult?.Invoke(false, null, null);
            }
        }

        private void SearchPaciente(byte[] template)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "SELECT PacienteID, Nombre, Apellido, Cedula FROM Paciente WHERE FingerprintTemplate = @template AND UsaHuella = 1",
                        connection);

                    command.Parameters.AddWithValue("@template", template);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int pacienteId = Convert.ToInt32(reader["PacienteID"]);
                            string nombre = reader["Nombre"].ToString();
                            string apellido = reader["Apellido"].ToString();
                            string cedula = reader["Cedula"].ToString();

                            string nombreCompleto = $"{nombre} {apellido}";

                            OnPacienteEncontrado?.Invoke(nombreCompleto, pacienteId, cedula);
                            OnStatusChanged?.Invoke($"Paciente encontrado: {nombreCompleto}");
                        }
                        else
                        {
                            OnStatusChanged?.Invoke("No se encontró paciente con esta huella");
                            OnPacienteEncontrado?.Invoke(null, 0, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error buscando paciente: {ex.Message}");
                OnPacienteEncontrado?.Invoke(null, 0, null);
            }
        }

        // Métodos de registro
        public bool RegisterFingerprint(string usuario, byte[] fingerprintTemplate)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "UPDATE login SET FingerprintTemplate = @template, UsaHuella = 1 WHERE Usuario = @usuario",
                        connection);

                    command.Parameters.AddWithValue("@template", fingerprintTemplate);
                    command.Parameters.AddWithValue("@usuario", usuario);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        OnStatusChanged?.Invoke("Huella registrada exitosamente en la base de datos");
                        OnRegistrationResult?.Invoke(true, "Huella registrada exitosamente");
                        return true;
                    }
                    else
                    {
                        OnStatusChanged?.Invoke("Usuario no encontrado");
                        OnRegistrationResult?.Invoke(false, "Usuario no encontrado");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error registrando huella en BD: {ex.Message}");
                OnRegistrationResult?.Invoke(false, $"Error: {ex.Message}");
                return false;
            }
        }

        public bool RegisterPacienteFingerprint(int pacienteId, byte[] fingerprintTemplate)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "UPDATE Paciente SET FingerprintTemplate = @template, UsaHuella = 1 WHERE PacienteID = @pacienteId",
                        connection);

                    command.Parameters.AddWithValue("@template", fingerprintTemplate);
                    command.Parameters.AddWithValue("@pacienteId", pacienteId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        OnStatusChanged?.Invoke("Huella del paciente registrada exitosamente");
                        OnRegistrationResult?.Invoke(true, "Huella del paciente registrada exitosamente");
                        return true;
                    }
                    else
                    {
                        OnStatusChanged?.Invoke("Paciente no encontrado");
                        OnRegistrationResult?.Invoke(false, "Paciente no encontrado");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error registrando huella del paciente: {ex.Message}");
                OnRegistrationResult?.Invoke(false, $"Error: {ex.Message}");
                return false;
            }
        }

        // Métodos de utilidad
        public byte[] GetCapturedTemplate()
        {
            return currentTemplate;
        }

        public bool CheckFingerprintAvailable(string usuario)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "SELECT UsaHuella FROM login WHERE Usuario = @usuario",
                        connection);

                    command.Parameters.AddWithValue("@usuario", usuario);

                    var result = command.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool CheckPacienteFingerprintAvailable(int pacienteId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "SELECT UsaHuella FROM Paciente WHERE PacienteID = @pacienteId",
                        connection);

                    command.Parameters.AddWithValue("@pacienteId", pacienteId);

                    var result = command.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
                }
            }
            catch
            {
                return false;
            }
        }

        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        public bool IsConnected()
        {
            return isConnected && serialPort?.IsOpen == true;
        }

        public FingerprintMode GetCurrentMode()
        {
            return currentMode;
        }

        public void CancelCurrentOperation()
        {
            currentState = ProcessState.Idle;
            OnStatusChanged?.Invoke("Operación cancelada");
        }

        // Método para probar comunicación básica
        public void TestCommunication()
        {
            if (!isConnected)
            {
                OnStatusChanged?.Invoke("Lector no conectado");
                return;
            }

            try
            {
                // Enviar comando de verificación (puede variar según el modelo)
                byte[] testCommand = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x16, 0x00, 0x1A };
                SendCommand(testCommand);
                OnStatusChanged?.Invoke("Comando de prueba enviado...");
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Error en prueba de comunicación: {ex.Message}");
            }
        }

        // Limpieza de recursos
        public void Dispose()
        {
            Disconnect();
            serialPort?.Dispose();
        }
    }
}
