CREATE PROCEDURE [dbo].[ObtenerVehiculos]
	-- Add the parameters for the stored procedure here
	AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Vehiculo.IdVehiculo, 
        Vehiculo.IdModelo, 
        Vehiculo.Placa, 
        Vehiculo.Color, 
        Vehiculo.Anio, 
        Vehiculo.Precio, 
        Vehiculo.CorreoPropietario, 
        Vehiculo.TelefonoPropietario, 
        Modelo.Nombre AS Modelo, 
        Marca.NombreMarca AS Marca
    FROM 
        Vehiculo
    INNER JOIN 
        Modelo ON Vehiculo.IdModelo = Modelo.IdModelo
    INNER JOIN 
        Marca ON Modelo.IdMarca = Marca.IdMarca
END