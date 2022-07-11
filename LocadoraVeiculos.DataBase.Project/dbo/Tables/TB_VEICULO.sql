CREATE TABLE [dbo].[TB_VEICULO] (
    [id_veiculo]        INT             IDENTITY (1, 1) NOT NULL,
    [modelo]            VARCHAR (50)    NULL,
    [placa]             VARCHAR (50)    NULL,
    [marca]             VARCHAR (50)    NULL,
    [cor]               VARCHAR (50)    NULL,
    [tipo_combustivel]  VARCHAR (50)    NULL,
    [capacidade_tanque] DECIMAL (18)    NULL,
    [ano_carro]         DATETIME        NULL,
    [quilometragem]     DECIMAL (18)    NULL,
    [foto_carro]        VARBINARY (MAX) NULL,
    CONSTRAINT [PK_TB_VEICULO] PRIMARY KEY CLUSTERED ([id_veiculo] ASC)
);

