using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxas : AbstractValidator<Taxas>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9]*$");
        public ValidadorTaxas()
        {
            RuleFor(x => x.Descricao).Cascade(CascadeMode.StopOnFirstFailure)
                .Matches(regEx).WithMessage("Não pode conter caracteres especial")
                .MinimumLength(8).WithMessage("A Descrição deve ter no minimo 8 caracteres")
                .NotNull().WithMessage("Deve ser inserido uma Descrição")
                .NotEmpty().WithMessage("Deve ser inserido uma Descrição");

            RuleFor(x => x.Valor)
                .NotNull().WithMessage("Deve ser inserido um valor")
                .NotEmpty().WithMessage("Deve ser inserido um valor");
        }
    }
}
