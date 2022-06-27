using LocadoraVeiculos.Dominio.shared;

namespace LocadoraVeiculos.Dominio.ModuloTaxas
{
    public class Taxas : EntidadeBase
    {
        public Taxas(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
