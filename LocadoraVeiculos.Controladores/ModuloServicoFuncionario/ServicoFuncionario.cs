using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario>
    {
        public ServicoFuncionario(RepositorioFuncionarioOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<Funcionario> PegarValidador()
        {
            return new ValidadorFuncionario();
        }

        protected override ValidationResult RegistroForValidoParaEditarBanco(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            Funcionario func1 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorNome(registro.Nome);
            if (func1 != null)
                if(func1.Nome == registro.Nome && func1.Id != registro.Id)
                    valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));

            Funcionario func2 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorUsuario(registro.Login);
            if (func2 != null)
                if(func2.Login == registro.Login && func2.Id != registro.Id)
                    valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorNome(registro.Nome);
            if (func1 != null) 
                valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));

            var func2 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorUsuario(registro.Login);
            if (func2 != null) 
                valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;
        }

    }
}
