CREATE TABLE [dbo].[TB_CONDUTORES] (
    [id_condutores] UNIQUEIDENTIFIER NOT NULL,
    [nome]          VARCHAR (50)     NULL,
    [cpf]           VARCHAR (50)     NULL,
    [endereco]      VARCHAR (50)     NULL,
    [email]         VARCHAR (50)     NULL,
    [telefone]      VARCHAR (50)     NULL,
    [cnh]           VARCHAR (50)     NULL,
    [validadeCnh]   VARCHAR (50)     NULL,
    CONSTRAINT [PK_TB_CONDUTORES_1] PRIMARY KEY CLUSTERED ([id_condutores] ASC)
);

