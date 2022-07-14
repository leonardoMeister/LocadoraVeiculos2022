CREATE TABLE [dbo].[TB_TAXAS] (
    [id_taxas]  UNIQUEIDENTIFIER NOT NULL,
    [descricao] VARCHAR (50)     NULL,
    [valor]     VARCHAR (50)     NULL,
    [tipo]      VARCHAR (50)     NULL,
    CONSTRAINT [PK_TB_TAXAS_1] PRIMARY KEY CLUSTERED ([id_taxas] ASC)
);







