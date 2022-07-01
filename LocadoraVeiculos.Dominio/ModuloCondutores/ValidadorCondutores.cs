using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloCondutores
{
    public class ValidadorCondutores : AbstractValidator<Condutores>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorCondutores()
        {
            RuleFor(x => x.Nome).Cascade(CascadeMode.StopOnFirstFailure)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .MinimumLength(8).WithMessage("O Nome deve ter no minimo 8 letras")
                .NotNull().WithMessage("Deve ser inserido um nome")
                .NotEmpty().WithMessage("Deve ser inserido um nome");

            RuleFor(x => x.Email)
               .Custom(ValidarEmail);

            RuleFor(x => x.Endereco).Cascade(CascadeMode.StopOnFirstFailure)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .NotNull().WithMessage("Deve ser inserido um endereço")
                .NotEmpty().WithMessage("Deve ser inserido um endereço");

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("Deve ser inserido um telefone")
                .NotEmpty().WithMessage("Deve ser inserido um telefone")
                .MinimumLength(13).WithMessage("Telefone deve ser Valido");

            RuleFor(x => Regex.IsMatch(x.Telefone, "[^0-9- ]+", RegexOptions.IgnoreCase))
                .NotEqual(true)
                .WithMessage("O telefone só deve conter números");

            RuleFor(x => x.Cnh).Cascade(CascadeMode.StopOnFirstFailure)
                .Matches(regEx).WithMessage("A CNH não deve possuir Caracteres Especiais")
                .MinimumLength(8).WithMessage("A CNH deve ter no minimo 8 letras")
                .NotNull().WithMessage("Deve ser inserido uma CNH")
                .NotEmpty().WithMessage("Deve ser inserido uma CNH");

            RuleFor(x => x.ValidadeCnh).Cascade(CascadeMode.StopOnFirstFailure)
                .Matches(regEx).WithMessage("Nome deve ser sem Caracteres Especiais")
                .NotNull().WithMessage("Deve ser inserido uma Validade para a CNH")
                .NotEmpty().WithMessage("Deve ser inserido uma Validade para a CNH");
        }

        private void ValidarEmail(string email, ValidationContext<Condutores> validacao)
        {
            if (!email.EmailValido()) validacao.AddFailure(new ValidationFailure("Email", "Email deve ser valido"));
        }

        private void ValidarCPF(Condutores condutor, ValidationContext<Condutores> validation)
        {
            if (condutor.Cpf.Length != 14)
                validation.AddFailure(new ValidationFailure("CPF", "O campo CPF deve ser Válido"));
        }
    }
}
