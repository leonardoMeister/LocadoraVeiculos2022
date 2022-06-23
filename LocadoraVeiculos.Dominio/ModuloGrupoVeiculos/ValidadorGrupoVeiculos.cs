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

            RuleFor(x => x.ListaCarros)
                .NotNull().WithMessage("Deve ser inserido uma Lista de Carros")
                .NotEmpty().WithMessage("Deve ser inserido uma Lista de Carros");
        }
    }
}
