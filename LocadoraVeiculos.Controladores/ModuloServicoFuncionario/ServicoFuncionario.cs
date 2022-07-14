using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario> 
    {
        protected override IRepository<Funcionario> PegarRepositorio()
        {
            return new RepositorioFuncionario(new MapeadorFuncionario());
        }
        protected override AbstractValidator<Funcionario> PegarValidador()
        {
            return new ValidadorFuncionario();
        }

        public override Result<Funcionario> Editar(Funcionario registro)
        {
            var validacaoBanco = FuncionarioForValidoParaEditar(registro);  //VALIDACAO DE BANCO

            if (validacaoBanco.IsValid)
            {
                return base.Editar(registro);                              //VALIDACAO DE DOMINIO
            }
            else
            {
                List<Error> listaErros = new List<Error>();

                foreach (var erro in validacaoBanco.Errors)
                {
                    listaErros.Add(new Error(erro.ErrorMessage));                    
                    Log.Logger.Warning("Falha ao tentar editar Funcionario {FuncionarioID} - {Motivo}",
                        registro._id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }

        public override Result<Funcionario> InserirNovo(Funcionario registro)
        {
            var validacaoBanco = FuncionarioForValidoParaInserir(registro);         //VALIDACAO DO BANCO
            if (validacaoBanco.IsValid)
            {                
                return base.InserirNovo(registro);                                  //VALIDACAO DO DOMINIO
            }
            else
            {
                List<Error> listaErros = new List<Error>();

                foreach (var erro in validacaoBanco.Errors)
                {
                    listaErros.Add(new Error(erro.ErrorMessage));
                    Log.Logger.Warning("Falha ao tentar Inserir Funcionario {FuncionarioID} - {Motivo}",
                        registro._id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }

        private ValidationResult FuncionarioForValidoParaEditar(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioFuncionario)Repositorio).SelecionarPorNome(registro.Nome);
            if (func1 != null && func1.Nome != registro.Nome) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));
            var func2 = ((RepositorioFuncionario)Repositorio).SelecionarPorUsuario(registro.Login);
            if (func2 != null && func1.Login != registro.Login) valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            var func1 = ((RepositorioFuncionario)Repositorio).SelecionarPorNome(registro.Nome);
            if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));
            var func2 = ((RepositorioFuncionario)Repositorio).SelecionarPorUsuario(registro.Login);
            if (func2 != null) valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;

        }
    }
}
