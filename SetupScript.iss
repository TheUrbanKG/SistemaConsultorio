[Setup]
; Información básica del programa
AppName=Sistema Consultorio
AppVersion=1.0
AppPublisher=TheUrbanKG
AppPublisherURL=https://github.com/TheUrbanKG
AppSupportURL=https://github.com/TheUrbanKG/SistemaConsultorio
AppUpdatesURL=https://github.com/TheUrbanKG/SistemaConsultorio

; Configuración de la instalación
DefaultDirName={pf}\SistemaConsultorio
DefaultGroupName=Sistema Consultorio
OutputDir=.\Instalador
OutputBaseFilename=Instalador_SistemaConsultorio
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64
PrivilegesRequired=admin

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Todo el contenido compilado (Ejecutable y dependencias DLLs)
Source: "sistema\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; Instalador de SQL Server Express (Debe estar en la misma carpeta que este script)
Source: "SQLEXPR_x64_ESN.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall ignoreversion

; El respaldo de la base de datos que proveíste
Source: "sistema\tesis_backup.bak"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Sistema Consultorio"; Filename: "{app}\sistema.exe"
Name: "{commondesktop}\Sistema Consultorio"; Filename: "{app}\sistema.exe"; Tasks: desktopicon

[Run]
; 0. Instalar SQL Server Express silenciosamente como instancia por defecto (MSSQLSERVER) para que responda a "localhost"
Filename: "{tmp}\SQLEXPR_x64_ESN.exe"; Parameters: "/Q /ACTION=Install /IACCEPTSQLSERVERLICENSETERMS /FEATURES=SQL /INSTANCENAME=MSSQLSERVER /SQLSVCACCOUNT=""NT AUTHORITY\Network Service"" /SQLSYSADMINACCOUNTS=""BUILTIN\ADMINISTRATORS"""; StatusMsg: "Instalando Base de Datos (Esto tomará varios minutos, no desesperes)..."; Flags: waituntilterminated

; 1. Comando para restaurar automáticamente la base de datos en SQL Server usando sqlcmd
; Intentamos ejecutar sqlcmd especificando una ruta común si la variable de entorno PATH aún no se ha actualizado.
Filename: "cmd.exe"; Parameters: "/c ""sqlcmd -E -S localhost -Q ""RESTORE DATABASE tesis FROM DISK = '{app}\tesis_backup.bak' WITH REPLACE"""""; Flags: runhidden runascurrentuser; StatusMsg: "Configurando la base de datos inicial..."

; 2. Opción para lanzar la aplicación al finalizar
Filename: "{app}\sistema.exe"; Description: "{cm:LaunchProgram,Sistema Consultorio}"; Flags: nowait postinstall skipifsilent runascurrentuser
