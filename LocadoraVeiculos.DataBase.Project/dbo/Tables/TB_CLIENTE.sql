CREATE TABLE [dbo].[TB_CLIENTE] (
    [id_cliente]  UNIQUEIDENTIFIER NOT NULL,
    [nome]        VARCHAR (50)     NULL,
    [cpf]         VARCHAR (50)     NULL,
    [endereco]    VARCHAR (50)     NULL,
    [email]       VARCHAR (50)     NULL,
    [telefone]    VARCHAR (50)     NULL,
    [tipoCliente] VARCHAR (50)     NULL,
    [cnpj]        VARCHAR (50)     NULL,
    CONSTRAINT [PK_TB_CLIENTE_1] PRIMARY KEY CLUSTERED ([id_cliente] ASC)
);







