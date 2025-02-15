-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerVehiculoPorId]
    @IdVehiculo UNIQUEIDENTIFIER -- Parámetro para buscar el vehículo
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Consulta el vehículo con el IdVehiculo proporcionado
        SELECT 
            [IdVehiculo],
            [IdModelo],
            [Placa],
            [Color],
            [Anio],
            [Precio],
            [CorreoPropietario],
            [TelefonoPropietario]
        FROM 
            [dbo].[Vehiculo]
        WHERE 
            [IdVehiculo] = @IdVehiculo;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        THROW;
    END CATCH
END;