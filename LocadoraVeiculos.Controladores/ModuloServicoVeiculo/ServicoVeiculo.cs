using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoVeiculo
{
    public class ServicoVeiculo : ServicoBase<Veiculo>
    {
        public ServicoVeiculo(RepositorioVeiculoOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<Veiculo> PegarValidador()
        {
            return new ValidadorVeiculo();
        }

        public Result<List<Veiculo>> SelecionarVeiculosPorGrupoVeiculos(GrupoVeiculos grupoVeiculo)
        {
            return Result.Ok(((RepositorioVeiculoOrm)Repositorio).SelecionarVeiculosPorGrupoVeiculos(grupoVeiculo));
        }


        protected override ValidationResult RegistroForValidoParaEditarBanco(Veiculo registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(Veiculo registro)
        {
            ValidationResult valido = new ValidationResult();

            return valido;
        }
    }
}
