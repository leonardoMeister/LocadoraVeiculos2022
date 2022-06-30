using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloCondutores;
using System;

namespace LocadoraVeiculos.Controladores.ModuloCondutores
{
    public class ControladorCondutores : Controlador<Condutores>
    {
        protected override IRepository<Condutores> PegarRepositorio()
        {
            throw new NotImplementedException();
        }

        protected override AbstractValidator<Condutores> PegarValidador()
        {
            throw new NotImplementedException();
        }
    }
}
