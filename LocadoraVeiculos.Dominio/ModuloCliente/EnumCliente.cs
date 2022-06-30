using System.ComponentModel;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public enum EnumCliente
    {
        [Description("Pessoa física")]
        PessoaFisica,

        [Description("Pessoa jurídica")]
        PessoaJuridica,
    }
}
