CREATE TABLE [dbo].[TB_FUNCIONARIO] (
    [id_funcionario] INT          IDENTITY (1, 1) NOT NULL,
    [nome]           VARCHAR (50) NULL,
    [login]          VARCHAR (50) NULL,
    [senha]          VARCHAR (50) NULL,
    [salario]        DECIMAL (18) NULL,
    [dataAdmicao]    DATETIME     NULL,
    [tipoPerfil]     VARCHAR (50) NULL,
    CONSTRAINT [PK_TB_FUNCIONARIO] PRIMARY KEY CLUSTERED ([id_funcionario] ASC)
);

