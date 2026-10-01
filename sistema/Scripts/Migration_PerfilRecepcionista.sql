-- =========================================================================
-- Migración: Soporte para perfil Recepcionista y asignación de citas a médicos
-- Issue #17
-- =========================================================================

USE [tesis];
GO

-- 1. Actualizar restricción CHECK en tabla login para admitir 'Recepcionista'
DECLARE @ConstraintName NVARCHAR(200);

SELECT @ConstraintName = cc.name
FROM sys.check_constraints cc
JOIN sys.columns c ON cc.parent_object_id = c.object_id AND cc.parent_column_id = c.column_id
JOIN sys.tables t ON cc.parent_object_id = t.object_id
WHERE t.name = 'login' AND c.name = 'Rol';

IF @ConstraintName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE [login] DROP CONSTRAINT ' + @ConstraintName);
    PRINT 'Restricción CHECK previa eliminada: ' + @ConstraintName;
END

ALTER TABLE [login] ADD CONSTRAINT CK_login_Rol CHECK (Rol IN ('Administrador', 'Usuario', 'Recepcionista', 'Auxiliar'));
PRINT 'Restricción CK_login_Rol creada exitosamente admitiendo Recepcionista.';
GO

-- 2. Agregar columna DoctorAsignado en tabla Cita si no existe
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('Cita') AND name = 'DoctorAsignado')
BEGIN
    ALTER TABLE [Cita] ADD DoctorAsignado NVARCHAR(100) NULL;
    PRINT 'Columna DoctorAsignado agregada a la tabla Cita.';
END
ELSE
BEGIN
    PRINT 'Columna DoctorAsignado ya existe en Cita.';
END
GO
