using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloCondutores
{
    public class ValidadorCondutores
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9- ]*$");
        public ValidadorCondutores()
        {

        }
    }
}
