using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;

namespace LocadoraVeiculos.Controladores.ModuloControladorTaxas
{
    public class ControladorTaxas : Controlador<Taxas>
    {
        public ControladorTaxas(AbstractValidator<Taxas> validator, IRepository<Taxas> repositorio) : base(validator, repositorio)
        {

        }
    }
}
