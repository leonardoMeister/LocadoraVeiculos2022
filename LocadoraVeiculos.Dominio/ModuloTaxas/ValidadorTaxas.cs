
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxas: AbstractValidator<Taxas>
    {
        public ValidadorTaxas()
        {
            RuleFor(x => x.Descricao)
                .MinimumLength(2).WithMessage("A Descrição deve ter no minimo 2 caracteres")
                .NotNull().WithMessage("Deve ser inserido uma Descrição")
                .NotEmpty().WithMessage("Deve ser inserido uma Descrição");

            RuleFor(x => x.Valor)
                .NotNull().WithMessage("Deve ser inserido um valor")
                .NotEmpty().WithMessage("Deve ser inserido um valor");
        }
    }
}
