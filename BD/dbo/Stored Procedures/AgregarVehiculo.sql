-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarVehiculo]
    @IdVehiculo UNIQUEIDENTIFIER,
    @IdModelo UNIQUEIDENTIFIER,
    @Placa VARCHAR(50), -- Limita el tamaño según sea necesario
    @Color VARCHAR(50), -- Limita el tamaño según sea necesario
    @Anio INT,
    @Precio DECIMAL(18, 2), -- Cambié la precisión para incluir centavos
    @CorreoPropietario VARCHAR(100), -- Limita el tamaño según sea necesario
    @TelefonoPropietario VARCHAR(20) -- Limita el tamaño según sea necesario
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Insertar datos en la tabla Vehiculo
        INSERT INTO [dbo].[Vehiculo] (
            [IdVehiculo],
            [IdModelo],
            [Placa],
            [Color],
            [Anio],
            [Precio],
            [CorreoPropietario],
            [TelefonoPropietario]
        )
        VALUES (
            @IdVehiculo,
            @IdModelo,
            @Placa,
            @Color,
            @Anio,
            @Precio,
            @CorreoPropietario,
            @TelefonoPropietario
        );
        
        -- Si todo sale bien, confirma la transacción
        COMMIT TRANSACTION;
        
        -- Retorna el ID del vehículo insertado
        SELECT @IdVehiculo AS VehiculoId;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, revierte la transacción
        ROLLBACK TRANSACTION;
        
        -- Maneja el error
        THROW;
    END CATCH
END;