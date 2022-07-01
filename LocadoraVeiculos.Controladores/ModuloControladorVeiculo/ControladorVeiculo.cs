using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloFuncionario;
using System;

namespace LocadoraVeiculos.Controladores.ModuloVeiculo
{
    public class ControladorVeiculo : Controlador<Veiculo>
    {
        protected override IRepository<Veiculo> PegarRepositorio()
        {
            throw new NotImplementedException();
        }

        protected override AbstractValidator<Veiculo> PegarValidador()
        {
            throw new NotImplementedException();
        }
    }
}
