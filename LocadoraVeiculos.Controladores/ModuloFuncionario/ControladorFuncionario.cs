using FluentValidation;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloFuncionario;

namespace LocadoraVeiculos.Controladores.ModuloFuncionario
{
    public class ControladorFuncionario : Controlador<Funcionario>
    {
        protected override IRepository<Funcionario> PegarRepositorio()
        {
            return new RepositorioFuncionario(new MapeadorFuncionario());
        }
        protected override AbstractValidator<Funcionario> PegarValidador()
        {
            return new ValidadorFuncionario();
        }
    }
}
