using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9]*$");

        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome).Cascade(CascadeMode.StopOnFirstFailure)
                .Matches(regEx)
                .MinimumLength(2).WithMessage("O Nome deve ter no minimo 2 caracteres e não pode conter special character(s)")
                .NotNull().NotEmpty();

            RuleFor(x => x.Login)
             .NotNull().WithMessage("Deve ser inserido um login")
             .NotEmpty().WithMessage("Deve ser inserido um login");

            RuleFor(x => x.Senha)
                .NotNull().WithMessage("Deve ser inserido uma senha")
                .NotEmpty().WithMessage("Deve ser inserido uma senha");

            RuleFor(x => x.Salario)
                .NotNull().WithMessage("Deve ser inserido um salario")
                .NotEmpty().WithMessage("Deve ser inserido um salario");

            RuleFor(x => x.DataAdmicao)
                .NotNull().WithMessage("Deve ser inserido uma Data de Admição")
                .NotEmpty().WithMessage("Deve ser inserido uma Data de Admição");

            RuleFor(x => x.DataAdmicao)
                .NotNull().WithMessage("Deve ser inserido um Tipo de Perfil")
                .NotEmpty().WithMessage("Deve ser inserido um Tipo de Perfil");

        }
    }
}
