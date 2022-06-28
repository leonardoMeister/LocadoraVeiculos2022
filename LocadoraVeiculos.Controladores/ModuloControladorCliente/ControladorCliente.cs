using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Controladores.ModuloControladorCliente
{
    public class ControladorCliente : Controlador<Cliente>
    {

        protected override IRepository<Cliente> PegarRepositorio()
        {
            return new RepositorioCliente(new MapeadorCliente());
        }

        protected override AbstractValidator<Cliente> PegarValidador()
        {
            return new ValidadorCliente();
        }
    }
}
