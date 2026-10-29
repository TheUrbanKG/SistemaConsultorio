-- ========================================================
-- Script 17: Tablas para el Módulo de Odontograma (Odontología)
-- ========================================================

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Odontograma')
BEGIN
    CREATE TABLE Odontograma (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        PacienteID INT NOT NULL,
        Fecha DATETIME NOT NULL DEFAULT GETDATE(),
        Tipo VARCHAR(50) NOT NULL DEFAULT 'Inicial', -- 'Inicial', 'Evolucion', 'Tratamiento'
        Observaciones NVARCHAR(MAX) NULL,
        FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
        FechaModificacion DATETIME NULL,
        CONSTRAINT FK_Odontograma_Paciente FOREIGN KEY (PacienteID) 
            REFERENCES Paciente(PacienteID) ON DELETE CASCADE
    );

    CREATE INDEX IX_Odontograma_PacienteID ON Odontograma(PacienteID);
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OdontogramaDiente')
BEGIN
    CREATE TABLE OdontogramaDiente (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        OdontogramaId INT NOT NULL,
        NumeroDiente INT NOT NULL,                            -- FDI: 11-18, 21-28, 31-38, 41-48
        CodigoEstado VARCHAR(50) NOT NULL DEFAULT 'sincarie', -- ej: 'sincarie', 'carie3', 'curada1', 'corona', etc.
        Categoria VARCHAR(50) NOT NULL DEFAULT 'Sano',        -- 'Sano', 'Caries', 'Curacion', 'Mixto', 'Protesis', etc.
        Observacion NVARCHAR(250) NULL,
        CONSTRAINT FK_OdontogramaDiente_Odontograma FOREIGN KEY (OdontogramaId) 
            REFERENCES Odontograma(Id) ON DELETE CASCADE,
        CONSTRAINT UQ_Odontograma_Diente UNIQUE (OdontogramaId, NumeroDiente)
    );

    CREATE INDEX IX_OdontogramaDiente_OdontogramaId ON OdontogramaDiente(OdontogramaId);
END;
