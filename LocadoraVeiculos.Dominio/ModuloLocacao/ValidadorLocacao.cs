using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorLocacao()
        {
            RuleFor(x => x.Veiculo)
                .NotNull().WithMessage("Veiculo deve ser selecionado.");

            RuleFor(x => x.Condutores)
                .NotNull().WithMessage("Condutores deve ser selecionado.");

            RuleFor(x => x.Cliente)
                .NotNull().WithMessage("Cliente deve ser selecionado.");

            RuleFor(x => x.GrupoVeiculos)
                .NotNull().WithMessage("Grupo de Veiculos deve ser selecionado.");

            RuleFor(x => x.PlanoCobranca)
                .NotNull().WithMessage("Plano Cobrança deve ser selecionado.");

            RuleFor(x => x.ListaTaxas)
                .NotNull().WithMessage("Lista de Taxas não pode ser Null.");
        }
    }
}
