CREATE TABLE [dbo].[TB_PLANOCOBRANCA] (
    [id_plano]               UNIQUEIDENTIFIER NOT NULL,
    [tipo_plano]             VARCHAR (50)     NOT NULL,
    [valor_por_diario]       DECIMAL (18)     NULL,
    [limite_de_kilometragem] DECIMAL (18)     NULL,
    [valor_por_km]           DECIMAL (18)     NULL,
    [grupo_veiculo_id]       UNIQUEIDENTIFIER              NOT NULL,
    CONSTRAINT [PK_TB_PLANOCOBRANCA_1] PRIMARY KEY CLUSTERED ([id_plano] ASC)
);



