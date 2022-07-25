using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoVeiculo 
{
    public class ServicoVeiculo : ServicoBase<Veiculo>
    {
        protected override IRepository<Veiculo> PegarRepositorio() 
        {
            return new RepositorioVeiculo(new MapeadorVeiculo());
        }

        protected override AbstractValidator<Veiculo> PegarValidador()
        {
            return new ValidadorVeiculo();
        }

        public override Result<Veiculo> InserirNovo(Veiculo registro)
        {
            var validacaoBanco = VeiculoForValidoParaInserir(registro);         //VALIDACAO DO BANCO
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
                    Log.Logger.Warning("Falha ao tentar Inserir Veiculo {VeiculoID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }

        public override Result<Veiculo> Editar(Veiculo registro)
        {
            var validacaoBanco = VeiculoForValidoParaEditar(registro);  //VALIDACAO DE BANCO

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
                    Log.Logger.Warning("Falha ao tentar editar Veiculo {VeiculoID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }

                return Result.Fail(listaErros);
            }
        }
        private ValidationResult VeiculoForValidoParaEditar(Veiculo registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
        private ValidationResult VeiculoForValidoParaInserir(Veiculo registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
    }
}
