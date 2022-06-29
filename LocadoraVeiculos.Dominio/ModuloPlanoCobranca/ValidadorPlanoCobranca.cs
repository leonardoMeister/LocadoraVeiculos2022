using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca
    {
        readonly Regex regEx = new Regex("^[a-zA-Z0-9]*$");
        public ValidadorPlanoCobranca()
        {

        }
    }
}
