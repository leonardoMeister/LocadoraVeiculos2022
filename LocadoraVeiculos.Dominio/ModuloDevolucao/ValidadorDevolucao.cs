using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorDevolucao()
        {
            RuleFor(x => x.Nome)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .MinimumLength(3).WithMessage("O Nome deve ter no minimo 3 letras")
                .NotNull().WithMessage("Deve ser inserido um nome")
                .NotEmpty().WithMessage("Deve ser inserido um nome");
        }
    }
}
