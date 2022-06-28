using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloTaxas;

namespace LocadoraVeiculos.Controladores.ModuloControladorTaxas
{
    public class ControladorTaxas : Controlador<Taxas>
    {
        protected override IRepository<Taxas> PegarRepositorio()
        {
            return new RepositorioTaxas(new MapeadorTaxas());
        }
        protected override AbstractValidator<Taxas> PegarValidador()
        {
            return new ValidadorTaxas();
        }
    }
}
