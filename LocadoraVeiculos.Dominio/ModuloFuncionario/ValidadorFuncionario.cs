using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");

        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .MinimumLength(3).WithMessage("O Nome deve ter no minimo 3 caracteres")
                .NotNull().NotEmpty();

            RuleFor(x => x.Login)
             .Matches(regEx).WithMessage("Login deve ser sem Caracteres Especiais")             
             .MinimumLength(3).WithMessage("O Login deve ter no minimo 3 caracteres")
             .NotNull().WithMessage("Deve ser inserido um login")
             .NotEmpty().WithMessage("Deve ser inserido um login");

            RuleFor(x => x.Senha)
                .Matches(regEx).WithMessage("Senha deve ser sem Caracteres Especiais")
                .NotNull().WithMessage("Deve ser inserido uma senha")
                .MinimumLength(8).WithMessage("A senha deve ter no minimo 8 caracteres e não pode conter special character(s)")
                .NotEmpty().WithMessage("Deve ser inserido uma senha");

            RuleFor(x => x.Salario)
                .NotNull().WithMessage("Deve ser inserido um salario")
                .NotEmpty().WithMessage("Deve ser inserido um salario");

            RuleFor(x => x.DataAdmicao)
                .NotNull().WithMessage("Deve ser inserido uma Data de Admição")
                .NotEmpty().WithMessage("Deve ser inserido uma Data de Admição");

        }
    }
}
