using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {
        public ValidadorGrupoVeiculos()
        {
            RuleFor(x => x.NomeGrupo)
                .NotEmpty();
        }
    }
}
