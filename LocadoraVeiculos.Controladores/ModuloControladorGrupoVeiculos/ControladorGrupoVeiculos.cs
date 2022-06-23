using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;

namespace LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos
{
    public class ControladorGrupoVeiculos : Controlador<GrupoVeiculos>
    {
        public ControladorGrupoVeiculos(AbstractValidator<GrupoVeiculos> validator, IRepository<GrupoVeiculos> repositorio) : base(validator, repositorio)
        {
        }
    }
}
