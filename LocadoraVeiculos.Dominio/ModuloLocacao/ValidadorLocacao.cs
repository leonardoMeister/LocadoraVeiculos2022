using FluentValidation;
using FluentValidation.Results;
using System;
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

            RuleFor(x => x.NivelTanqueEnumInicio)
                .NotEmpty().WithMessage("Nivel do tanque deve ser informado");

            RuleFor(x => x.GrupoVeiculos)
                .NotNull().WithMessage("Grupo de Veiculos deve ser selecionado.");

            RuleFor(x => x.PlanoCobranca)
                .NotNull().WithMessage("Plano Cobrança deve ser selecionado.");

            RuleFor(x => x.ListaTaxas)
                .NotNull().WithMessage("Lista de Taxas não pode ser Null.");

            RuleFor(x => x.QuilometragemInicial)
                .NotEqual(0).WithMessage("Quilometragem Inicial deve ser informada");

            RuleFor(x => x.DataEstimadaDevolucao).Custom(DataEstimadaLocacaoNaoPodeSerNoPassado);
            RuleFor(x => x).Custom(ValidarDataFinalDevolucao);
            RuleFor(x => x).Custom(ValidarKmFinal);
            RuleFor(x => x).Custom(SeForDevolucaoTodosOsCamposDevemSerPreenchidos);
        }

        private void SeForDevolucaoTodosOsCamposDevemSerPreenchidos(Locacao loc, ValidationContext<Locacao> validation)
        {
            if (loc.StatusDevolucao)
            {
                if(loc.QuilometragemFinal == 0)
                {
                    validation.AddFailure(new ValidationFailure("QuilometragemFinal", "Quilometragem Final deve ser informado"));
                }
                if(loc.DataRealDaDevolucao.Date == loc.DataLocacao.Date || loc.DataRealDaDevolucao == DateTime.MinValue)
                {
                    validation.AddFailure(new ValidationFailure("DataDevolucao", "Data da Devolucao não pode ser no mesmo dia da locacao"));
                }                
            }
        }

        private void DataEstimadaLocacaoNaoPodeSerNoPassado(DateTime data, ValidationContext<Locacao> validation)
        {
            if (data < DateTime.Now)
            {
                validation.AddFailure(new ValidationFailure("DataEstimadaDevolucao", "A Data da devolucao não pode ser antes da data de locacao"));
            }
        }

        private void ValidarKmFinal(Locacao loc, ValidationContext<Locacao> validation)
        {
            if(loc.QuilometragemInicial> loc.QuilometragemFinal)
            {
                validation.AddFailure(new ValidationFailure("QuilometragemAtual", "A quilometragem atual do carro nao pode ser inferior a inicial"));
            }
        } 

        private void ValidarDataFinalDevolucao(Locacao loc, ValidationContext<Locacao> validation)
        {
            if(loc.DataLocacao > loc.DataRealDaDevolucao)
            {
                validation.AddFailure(new ValidationFailure("DataDevolucao", "A Data da devolucao não pode ser antes da data de locacao"));
            }

        }
    }
}
