CREATE TABLE [dbo].[TB_PLANOCOBRANCA] (
    [id_plano]               INT          IDENTITY (1, 1) NOT NULL,
    [tipo_plano]             VARCHAR (50) NOT NULL,
    [valor_por_diario]       DECIMAL (18) NULL,
    [limite_de_kilometragem] DECIMAL (18) NULL,
    [valor_por_km]           DECIMAL (18) NULL,
    [grupo_veiculo_id]       INT          NOT NULL,
    CONSTRAINT [PK_TB_PLANOCOBRANCA] PRIMARY KEY CLUSTERED ([id_plano] ASC),
    CONSTRAINT [FK_grupoVeiculo_PlanoCobranca] FOREIGN KEY ([grupo_veiculo_id]) REFERENCES [dbo].[TB_GRUPOVEICULOS] ([id_grupoveiculos])
);

