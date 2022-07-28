using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.shared;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorLocacao()
        {
           
        }
    }
}
