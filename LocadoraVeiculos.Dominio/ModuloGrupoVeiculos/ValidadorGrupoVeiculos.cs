using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            RuleFor(x => x.NomeGrupo)
                .NotNull().WithMessage("Deve ser inserido um Nome")
                .NotEmpty().WithMessage("Deve ser inserido um Nome");
            
        }
    }
}
