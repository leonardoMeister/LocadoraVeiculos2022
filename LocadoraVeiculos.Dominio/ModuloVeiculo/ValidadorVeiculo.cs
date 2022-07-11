using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Ano)
                .NotEqual(DateTime.MinValue).WithMessage("Ano deve ser informado.");

            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("Modelo Deve ser informado.")
                .MinimumLength(8).WithMessage("Modelo deve ter mais que 8 letras.");

            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("Placa Deve ser informado.")
                .MinimumLength(8).WithMessage("Placa deve ter no minimo 8 letras.")
                .MaximumLength(8).WithMessage("Placa deve ter no maximo 8 letras.");

            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("Marca Deve ser informado.")
                .MinimumLength(3).WithMessage("Marca deve ter no minimo 3 letras.");

            RuleFor(x => x.Cor)
                .NotEmpty().WithMessage("Cor Deve ser informado.")
                .MinimumLength(3).WithMessage("Cor deve ter no minimo 3 letras.");

            RuleFor(x => x.TipoCombustivel)
                .NotEmpty().WithMessage("Tipo do combustivel Deve ser informado.")
                .MinimumLength(8).WithMessage("Tipo do combustivel deve ter no minimo 8 letras.");

            RuleFor(x => x.CapacidadeTanque)
                .NotEqual(0).WithMessage("Capacidade do tanque deve ser informada");

            RuleFor(x => x.Quilometragem)
                .NotEqual(0).WithMessage("Quilometragem deve ser informada");

            RuleFor(x => x.GrupoVeiculos)
                .NotNull().WithMessage("Grupo de Veiculos deve ser selecionado.");
        }
    }
}
