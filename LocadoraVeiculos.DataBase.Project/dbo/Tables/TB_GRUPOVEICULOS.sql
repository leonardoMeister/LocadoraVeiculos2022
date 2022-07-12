CREATE TABLE [dbo].[TB_GRUPOVEICULOS] (
    [id_grupoveiculos] UNIQUEIDENTIFIER NOT NULL,
    [nomeGrupo]        VARCHAR (50)     NULL,
    CONSTRAINT [PK_TB_GRUPOVEICULOS_1] PRIMARY KEY CLUSTERED ([id_grupoveiculos] ASC)
);



