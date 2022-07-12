using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using Serilog;
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

        public override ValidationResult InserirNovo(Veiculo registro)
        {
            Log.Logger.Debug("Veiculo {VeiculoID} editado com sucesso", registro._id);

            return base.InserirNovo(registro);
        }

        public override ValidationResult Editar(Veiculo registro)
        {
            Log.Logger.Debug("Veiculo {VeiculoID} editado com sucesso", registro._id);

            return base.Editar(registro);
        }
    }
}
