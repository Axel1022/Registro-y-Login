/*
    Base de datos
*/

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'REGISTROLOGIN')
BEGIN
    CREATE DATABASE nombre_de_la_base_de_datos;
END;

USE REGISTROLOGIN

if not exists (select 1 from sys.tables where name = 'registros')
BEGIN
    CREATE TABLE registros
    (
        id int identity(1,1) PRIMARY KEY ,
        Nombre VARCHAR(50),
        Correo VARCHAR(100),
        Edad int,
        Usuario VARCHAR(50),
        Clave VARCHAR(50)
    )
end;


IF NOT EXISTS (SELECT 1 FROM sys.procedures WHERE name = 'sp_registrar')
BEGIN
    EXEC('CREATE PROCEDURE sp_registrar
    @Nombre VARCHAR(50),
    @Correo VARCHAR(100),
    @Edad INT,
    @Usuario VARCHAR(50),
    @Clave VARCHAR(50)
AS
BEGIN
    INSERT INTO registros VALUES (@Nombre, @Correo, @Edad, @Usuario, @Clave)
END;');
END;

IF NOT EXISTS (SELECT 1 FROM sys.procedures WHERE name = 'sp_login')
BEGIN
    EXEC('CREATE PROCEDURE sp_login
    @Usuario VARCHAR(50),
    @Clave VARCHAR(50)
AS
BEGIN
    Select * FROM registros WHERE Usuario = @Usuario and Clave = @Clave
END;');
END;

INSERT INTO registros (Nombre, Correo, Edad, Usuario, Clave)
VALUES
  ('Juan Perez', 'juan.perez@correo.com', 30, 'jperez', 'clave123'),
  ('Maria Garcia', 'maria.garcia@correo.com', 25, 'mgarcia', 'miclave'),
  ('Pedro Lopez', 'pedro.lopez@correo.com', 40, 'plopez', 'claveSegura');


select * from registros

