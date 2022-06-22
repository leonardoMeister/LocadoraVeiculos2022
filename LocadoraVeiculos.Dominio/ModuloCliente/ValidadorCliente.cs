using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Deve ser inserido um nome")
                .NotEmpty().WithMessage("Deve ser inserido um nome");

            RuleFor(x => x.Cpf)
                .MinimumLength(11).WithMessage("O CPF deve ter 11 dígitos")
                .MaximumLength(11).WithMessage("O CPF deve ter 11 dígitos")
                .NotNull().NotEmpty();

            RuleFor(x => x.Endereco)
                .NotNull().WithMessage("Deve ser inserido um endereço")
                .NotEmpty().WithMessage("Deve ser inserido um endereço");

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("Deve ser inserido um telefone")
                .NotEmpty().WithMessage("Deve ser inserido um telefone");

            RuleFor(x => Regex.IsMatch(x.Telefone, "[^0-9]+", RegexOptions.IgnoreCase))
                .NotEqual(true)
                .WithMessage("O telefone só deve conter números");

            RuleFor(x => Regex.IsMatch(x.Cpf, "[^0-9]+", RegexOptions.IgnoreCase))
                .NotEqual(true)
                .WithMessage("O CPF só pode conter números");
        }
    }
}
