CREATE TABLE [dbo].[Marca] (
    [IdMarca]     UNIQUEIDENTIFIER NOT NULL,
    [NombreMarca] VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED ([IdMarca] ASC)
);

