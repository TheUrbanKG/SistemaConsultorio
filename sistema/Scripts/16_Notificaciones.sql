ALTER TABLE Paciente ADD CanalNotificacionPreferido VARCHAR(50) NULL DEFAULT 'Ninguno';
ALTER TABLE Paciente ADD TelegramChatId VARCHAR(100) NULL;

CREATE TABLE HistorialNotificaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CitaID INT NOT NULL,
    Canal VARCHAR(50) NOT NULL,
    Estado VARCHAR(50) NOT NULL, -- Pendiente, Enviado, Error
    FechaEnvio DATETIME NULL,
    DetallesError NVARCHAR(MAX) NULL,
    CONSTRAINT FK_HistorialNotificaciones_Cita FOREIGN KEY (CitaID) REFERENCES Cita(CitaID) ON DELETE CASCADE
);
