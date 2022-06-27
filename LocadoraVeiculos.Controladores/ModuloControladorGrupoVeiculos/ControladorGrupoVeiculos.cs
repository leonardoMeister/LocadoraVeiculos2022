using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;

namespace LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos
{
    public class ControladorGrupoVeiculos : Controlador<GrupoVeiculos>
    {
        public ControladorGrupoVeiculos(AbstractValidator<GrupoVeiculos> validator, IRepositoryGrupoVeiculos repositorio) : base(validator, repositorio)
        {
        }
    }
}
