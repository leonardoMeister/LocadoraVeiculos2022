using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca>
    {
        public ServicoPlanoCobranca(RepositorioPlanoCobrancaOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }        

        protected override AbstractValidator<PlanoCobranca> PegarValidador()
        {
            return new ValidadorPlanoCobranca();
        }
        public override Result<PlanoCobranca> InserirNovo(PlanoCobranca registro)
        {
            var validacaoBanco = PlanoCobrancaForValidoParaInserir(registro);         //VALIDACAO DO BANCO
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
                    Log.Logger.Warning("Falha ao tentar Inserir Plano Cobranca {PlanoCobrancaID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);
            }
        }
       
        public override Result<PlanoCobranca> Editar(PlanoCobranca registro)
        {
            var validacaoBanco = PlanoCobrancaForValidoParaEditar(registro);  //VALIDACAO DE BANCO

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
                    Log.Logger.Warning("Falha ao tentar editar Plano Cobraca {PlanoCobrancaID} - {Motivo}",
                        registro.Id, erro.ErrorMessage);
                }
                return Result.Fail(listaErros);

            }
        }
        private ValidationResult PlanoCobrancaForValidoParaInserir(PlanoCobranca registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
        private ValidationResult PlanoCobrancaForValidoParaEditar(PlanoCobranca registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }

        public Result<List<PlanoCobranca>> SelecionarPlanoCobrancaPorGrupoVeiculo(GrupoVeiculos grupoVeiculo)
        {
            return Result.Ok(((RepositorioPlanoCobrancaOrm)Repositorio).SelecionarPlanoCobrancaPorGrupoVeiculo(grupoVeiculo));
        }
    }
}
