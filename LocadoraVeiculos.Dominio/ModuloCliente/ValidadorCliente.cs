using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .MinimumLength(3).WithMessage("O Nome deve ter no minimo 3 letras")
                .NotNull().WithMessage("Deve ser inserido um nome")
                .NotEmpty().WithMessage("Deve ser inserido um nome");

            RuleFor(x => x.Email)
               .Custom(ValidarEmail);

            RuleFor(x => x)
                .Custom(ValidarTipoCliente);
           
            RuleFor(x => x.Endereco)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .NotNull().WithMessage("Deve ser inserido um endereço")
                .NotEmpty().WithMessage("Deve ser inserido um endereço")
                .MinimumLength(8).WithMessage("Deve ter mais que 7 caracteres");
            
            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("Deve ser inserido um telefone")
                .NotEmpty().WithMessage("Deve ser inserido um telefone")
                .MinimumLength(13).WithMessage("Telefone deve ser Valido");
            
            RuleFor(x => Regex.IsMatch(x.Telefone, "[^0-9- ]+", RegexOptions.IgnoreCase))
                .NotEqual(true)
                .WithMessage("O telefone só deve conter números");
        }

        private void ValidarEmail(string email, ValidationContext<Cliente> validacao)
        {
            if (!email.EmailValido()) validacao.AddFailure(new ValidationFailure("Email", "Email deve ser valido"));
        }

        private void ValidarTipoCliente(Cliente cliente, ValidationContext<Cliente> validation)
        {
            if (cliente.TipoCliente == EnumCliente.PessoaFisica.ToString())
            {
                ValidarCPF(cliente, validation);
            }
            else
            {
                ValidarCNPJ(cliente, validation);
            }
        }
        private void ValidarCPF(Cliente cliente, ValidationContext<Cliente> validation)
        {
            if (cliente.Cpf.Length != 14)
                validation.AddFailure(new ValidationFailure("CPF", "O campo CPF deve ser Válido"));
        }

        private void ValidarCNPJ(Cliente cliente, ValidationContext<Cliente> validation)
        {
            if (cliente.Cnpj.Length != 18)
                validation.AddFailure(new ValidationFailure("CNPJ", "O Campo CNPJ deve ser Válido"));
        }
    }
}
