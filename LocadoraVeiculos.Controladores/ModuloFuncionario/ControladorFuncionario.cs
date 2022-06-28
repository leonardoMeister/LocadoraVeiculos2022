using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Repositorio.shared;

namespace LocadoraVeiculos.Controladores.ModuloFuncionario
{
    public class ControladorFuncionario : Controlador<Funcionario>
    {
        public ControladorFuncionario(AbstractValidator<Funcionario> validator, IRepository<Funcionario> repositorio) : base(validator, repositorio)
        {
        }
    }
}
