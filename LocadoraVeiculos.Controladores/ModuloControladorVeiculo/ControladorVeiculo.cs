using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloVeiculo;
using Serilog;
using System;

namespace LocadoraVeiculos.Controladores.ModuloVeiculo
{
    public class ControladorVeiculo : Controlador<Veiculo>
    {
        protected override IRepository<Veiculo> PegarRepositorio() 
        {
            return new RepositorioVeiculo(new MapeadorVeiculo());
        }

        protected override AbstractValidator<Veiculo> PegarValidador()
        {
            return new ValidadorVeiculo();
        }

        public override ValidationResult InserirNovo(Veiculo registro)
        {
            Log.Logger.Debug("Veiculo {VeiculoID} editado com sucesso", registro._id);

            return base.InserirNovo(registro);
            //Log.Logger.Debug("Veiculo {VeiculoNome} editado com sucesso", registro._id);
        }

        public override ValidationResult Editar(Veiculo registro)
        {
            Log.Logger.Debug("Veiculo {VeiculoID} editado com sucesso", registro._id);

            return base.Editar(registro);
            //Log.Logger.Debug("Veiculo {VeiculoNome} editado com sucesso", registro._id);
        }
    }
}
