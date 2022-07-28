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
        public ServicoFuncionario(RepositorioFuncionarioOrm repo, IContextoPersistencia contexto) : base(repo,contexto)
        {

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
                        registro.Id, erro.ErrorMessage);
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
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }

        private ValidationResult FuncionarioForValidoParaEditar(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            //Funcionario func1 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorNome(registro.Nome);
            //if (func1 != null && func1.Nome != registro.Nome) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));
            //Funcionario func2 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorUsuario(registro.Login);
            //if (func2 != null && func1.Login != registro.Login) valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;
        }
        private ValidationResult FuncionarioForValidoParaInserir(Funcionario registro)
        {
            ValidationResult valido = new ValidationResult();

            //var func1 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorNome(registro.Nome);
            //if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nomes repetidos"));
            //var func2 = ((RepositorioFuncionarioOrm)Repositorio).SelecionarPorUsuario(registro.Login);
            //if (func2 != null) valido.Errors.Add(new ValidationFailure("login", "Nao pode ter login repetidos"));

            return valido;

        }
    }
}
