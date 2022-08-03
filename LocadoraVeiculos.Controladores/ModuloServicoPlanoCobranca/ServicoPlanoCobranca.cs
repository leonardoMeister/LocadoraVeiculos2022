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

        public Result<List<PlanoCobranca>> SelecionarPlanoCobrancaPorGrupoVeiculo(GrupoVeiculos grupoVeiculo)
        {
            return Result.Ok(((RepositorioPlanoCobrancaOrm)Repositorio).SelecionarPlanoCobrancaPorGrupoVeiculo(grupoVeiculo));
        }

        protected override ValidationResult RegistroForValidoParaEditarBanco(PlanoCobranca registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(PlanoCobranca registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
    }
}
