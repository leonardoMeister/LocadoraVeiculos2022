using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Controladores.ModuloControladorCliente
{
    public class ControladorCliente : Controlador<Cliente>
    {
        public ControladorCliente(AbstractValidator<Cliente> validator, IRepository<Cliente> repositorio) : base(validator, repositorio)
        {
        }
    }
}
