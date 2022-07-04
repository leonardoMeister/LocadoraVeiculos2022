using FluentValidation;
using FluentValidation.Results;
using System;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca: AbstractValidator<PlanoCobranca>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.TipoPlano)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Tipo não pode ser vazio.")
                .NotNull().WithMessage("Tipo não pode ser vazio.")
                .MinimumLength(8).WithMessage("Tipo do plano deve ter no minimo 8 letras")
                .Matches(regEx).WithMessage("Tipo não pode conter caracteres espaciais");

            RuleFor(x => x.GrupoVeiculos)
                .NotNull().WithMessage("Grupo de veiculos deve ser selecionado");

            RuleFor(x => x).Custom(ValidarRegra);
        }

        private void ValidarRegra(PlanoCobranca plano, ValidationContext<PlanoCobranca> validador)
        {
            if(plano.LimiteKM != 0)
            {
                if (plano.ValorDia == 0 && plano.ValorKM == 0)
                {
                    validador.AddFailure(new ValidationFailure("Valores", "Se limiteKM for maior que 0, especifique um outro preço."));
                    return;
                }                
            }
            if(plano.ValorDia == 0 && plano.ValorKM == 0)
                validador.AddFailure(new ValidationFailure("Valores", "Você deve especificar um tipo de valor de cobrança (ValorDia, ValorKM)."));
        }
    }
}
