using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorVeiculo()
        {

        }
    }
}
