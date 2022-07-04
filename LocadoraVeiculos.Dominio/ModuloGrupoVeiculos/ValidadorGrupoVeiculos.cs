using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorGrupoVeiculos()
        {
            RuleFor(x => x.NomeGrupo)
               .Matches(regEx).WithMessage("Não pode contar caractere especial")
               .MinimumLength(8).WithMessage("A Descrição deve ter no minimo 8 letras")
               .NotNull().WithMessage("Deve ser inserido um Nome")
               .NotEmpty().WithMessage("Deve ser inserido um Nome");

        }
    }
}
