CREATE TABLE [dbo].[TB_FUNCIONARIO] (
    [id_funcionario] UNIQUEIDENTIFIER NOT NULL,
    [nome]           VARCHAR (50)     NULL,
    [login]          VARCHAR (50)     NULL,
    [senha]          VARCHAR (50)     NULL,
    [salario]        DECIMAL (18)     NULL,
    [dataAdmicao]    DATETIME         NULL,
    [tipoPerfil]     VARCHAR (50)     NULL,
    CONSTRAINT [PK_TB_FUNCIONARIO_1] PRIMARY KEY CLUSTERED ([id_funcionario] ASC)
);



