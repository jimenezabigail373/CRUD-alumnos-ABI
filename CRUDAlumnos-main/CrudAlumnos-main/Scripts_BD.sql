-- =============================================
-- Script Base de Datos: CrudAlumnos
-- =============================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CrudAlumnos')
BEGIN
    CREATE DATABASE CrudAlumnos;
END
GO

USE CrudAlumnos;
GO

-- Tabla Ciudades
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Ciudades' AND xtype='U')
BEGIN
    CREATE TABLE Ciudades (
        CodCiudad   INT IDENTITY(1,1) PRIMARY KEY,
        Nombre      NVARCHAR(100) NOT NULL
    );
END
GO

-- Tabla Alumnos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Alumnos' AND xtype='U')
BEGIN
    CREATE TABLE Alumnos (
        CodAlumno   INT IDENTITY(1,1) PRIMARY KEY,
        Nombre      NVARCHAR(100) NOT NULL,
        Apellido    NVARCHAR(100) NOT NULL,
        Edad        INT NOT NULL,
        Sexo        CHAR(1) NOT NULL CHECK (Sexo IN ('M','F')),
        CodCiudad   INT NOT NULL,
        CONSTRAINT FK_Alumnos_Ciudades FOREIGN KEY (CodCiudad)
            REFERENCES Ciudades(CodCiudad)
    );
END
GO

-- Datos de prueba Ciudades
IF NOT EXISTS (SELECT TOP 1 1 FROM Ciudades)
BEGIN
    INSERT INTO Ciudades (Nombre) VALUES
        ('Lima'),
        ('Trujillo'),
        ('Arequipa'),
        ('Cusco'),
        ('Piura'),
        ('Chiclayo'),
        ('Iquitos'),
        ('Managua'),
        ('Granada'),
        ('León');
END
GO

-- Datos de prueba Alumnos
IF NOT EXISTS (SELECT TOP 1 1 FROM Alumnos)
BEGIN
    INSERT INTO Alumnos (Nombre, Apellido, Edad, Sexo, CodCiudad) VALUES
        ('Pedro',   'Ramírez',   21, 'M', 1),
        ('Micaela', 'Torres',    19, 'F', 2),
        ('Juan',    'García',    22, 'M', 3),
        ('Ana',     'López',     20, 'F', 4);
END
GO
