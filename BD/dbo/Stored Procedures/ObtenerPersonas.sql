-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerPersonas
AS
BEGIN
    SELECT Id, Nombre, Apellido, Correo
    FROM Personas;
END;