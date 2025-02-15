CREATE TABLE [dbo].[Modelo] (
    [IdModelo] UNIQUEIDENTIFIER NOT NULL,
    [IdMarca]  UNIQUEIDENTIFIER NOT NULL,
    [Nombre]   VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED ([IdModelo] ASC),
    CONSTRAINT [FK_Modelo_Marca] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marca] ([IdMarca])
);

