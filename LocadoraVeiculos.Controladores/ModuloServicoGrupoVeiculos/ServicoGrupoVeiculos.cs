using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos
{
    public class ServicoGrupoVeiculos : ServicoBase<GrupoVeiculos>
    {
        public ServicoGrupoVeiculos(RepositorioGrupoVeiculoOrm repo, IContextoPersistencia contexto) : base(repo, contexto)
        {

        }

        protected override AbstractValidator<GrupoVeiculos> PegarValidador()
        {
            return new ValidadorGrupoVeiculos();
        }

        protected override ValidationResult RegistroForValidoParaEditarBanco(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            //GrupoVeiculos func1 = ((RepositorioGrupoVeiculoOrm)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            //if (func1 != null && func1.Id != registro.Id) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;
        }

        protected override ValidationResult RegistroForValidoParaInserirBanco(GrupoVeiculos registro)
        {
            ValidationResult valido = new ValidationResult();

            //GrupoVeiculos func1 = ((RepositorioGrupoVeiculoOrm)Repositorio).SelecionarPorNome(registro.NomeGrupo);
            //if (func1 != null) valido.Errors.Add(new ValidationFailure("Nome", "Nao pode ter nome repetido"));

            return valido;
        }

    }
}
