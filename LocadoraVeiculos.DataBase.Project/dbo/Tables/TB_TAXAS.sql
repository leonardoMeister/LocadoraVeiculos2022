CREATE TABLE [dbo].[TB_TAXAS] (
    [id_taxas]  INT          IDENTITY (1, 1) NOT NULL,
    [descricao] VARCHAR (50) NULL,
    [valor]     VARCHAR (50) NULL,
    CONSTRAINT [PK_TB_TAXAS] PRIMARY KEY CLUSTERED ([id_taxas] ASC)
);



