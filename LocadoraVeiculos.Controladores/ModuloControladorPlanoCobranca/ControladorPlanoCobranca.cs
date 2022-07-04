using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloPlanoCobranca;
using System;

namespace LocadoraVeiculos.Controladores.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : Controlador<PlanoCobranca>
    {
        protected override IRepository<PlanoCobranca> PegarRepositorio()
        {
            return new RepositorioPlanoCobranca(new MapeadorPlanoCobranca());
        }

        protected override AbstractValidator<PlanoCobranca> PegarValidador()
        {
            return new ValidadorPlanoCobranca();
        }
        public override ValidationResult InserirNovo(PlanoCobranca registro)
        {
            return base.InserirNovo(registro);
        }

        public override ValidationResult Editar(PlanoCobranca registro)
        {
            return base.Editar(registro);
        }
    }
}
