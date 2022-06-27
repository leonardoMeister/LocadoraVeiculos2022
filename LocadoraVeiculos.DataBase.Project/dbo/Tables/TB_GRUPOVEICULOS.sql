CREATE TABLE [dbo].[TB_GRUPOVEICULOS] (
    [id_grupoveiculos] INT          IDENTITY (1, 1) NOT NULL,
    [nomeGrupo]           VARCHAR (50) NULL,
    CONSTRAINT [PK_TB_GRUPOVEICULOS] PRIMARY KEY CLUSTERED ([id_grupoveiculos] ASC)
);

