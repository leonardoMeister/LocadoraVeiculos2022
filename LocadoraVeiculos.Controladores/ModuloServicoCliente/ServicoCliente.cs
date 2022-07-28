using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoCliente
{ 
    public class ServicoCliente : ServicoBase<Cliente> 
    {
        public ServicoCliente(RepositorioClienteOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<Cliente> PegarValidador()
        {
            return new ValidadorCliente();
        }
        public override Result<Cliente> Editar(Cliente registro)
        {
            var validacaoBanco = ClienteForValidoParaEditar(registro);  //VALIDACAO DE BANCO

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
                    Log.Logger.Warning("Falha ao tentar editar Cliente {ClienteID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }
        public override Result<Cliente> InserirNovo(Cliente registro)
        {
            var validacaoBanco = ClienteForValidoParaInserir(registro);         //VALIDACAO DO BANCO
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
                    Log.Logger.Warning("Falha ao tentar Inserir Cliente {Cliente} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }        

        private ValidationResult ClienteForValidoParaEditar(Cliente registro)
        {
            ValidationResult valido = new ValidationResult();

            //Cliente func1 = ((RepositorioClienteOrm)Repositorio).SelecionarPorCpf(registro.Cpf);
            //if (func1 != null && func1.Id != registro.Id)
            //{
            //    if (func1.Cpf != "   .   .   -")
            //    {
            //        valido.Errors.Add(new ValidationFailure("Cpf", "Nao pode ter Cpf repetido"));
            //    }

            //}

            //Cliente func2 = ((RepositorioClienteOrm)Repositorio).SelecionarPorCnpj(registro.Cnpj);
            //if (func2 != null && func2.Id != registro.Id)
            //{
            //    if (func2.Cnpj != "  .   .   /    -")
            //    {
            //        valido.Errors.Add(new ValidationFailure("Cnpj", "Nao pode ter Cnpj repetido"));
            //    }

            //}

            return valido;
        }
        private ValidationResult ClienteForValidoParaInserir(Cliente registro)
        {
            ValidationResult valido = new ValidationResult();

            //var func1 = ((RepositorioClienteOrm)Repositorio).SelecionarPorCpf(registro.Cpf);
            //if (func1 != null)
            //{
            //    if (func1.Cpf != "   .   .   -")
            //    {
            //        valido.Errors.Add(new ValidationFailure("Cpf", "Nao pode ter Cpf repetido"));
            //    }

            //}
            //var func2 = ((RepositorioClienteOrm)Repositorio).SelecionarPorCnpj(registro.Cnpj);
            //if (func2 != null)
            //{
            //    if (func2.Cnpj != "  .   .   /    -")
            //    {
            //        valido.Errors.Add(new ValidationFailure("Cnpj", "Nao pode ter Cnpj repetido"));
            //    }

            //}

            return valido;

        }
    }
}
