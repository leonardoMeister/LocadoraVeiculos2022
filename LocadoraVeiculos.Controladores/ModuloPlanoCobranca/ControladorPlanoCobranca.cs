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
            throw new NotImplementedException();
        }

        protected override AbstractValidator<PlanoCobranca> PegarValidador()
        {
            throw new NotImplementedException();
        }
    }
}
