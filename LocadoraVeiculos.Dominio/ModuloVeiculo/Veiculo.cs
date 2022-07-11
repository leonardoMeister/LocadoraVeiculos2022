using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase
    {
        public string Modelo;
        public string Placa;
        public string Marca;
        public string Cor;
        public string TipoCombustivel;
        public string CapacidadeTanque;
        public string Ano;
        public string Quilometragem;
        public string Foto;
        public GrupoVeiculos GrupoVeiculos;

        public Veiculo()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   _id == veiculo._id &&
                   Modelo == veiculo.Modelo &&
                   Placa == veiculo.Placa &&
                   Marca == veiculo.Marca &&
                   Cor == veiculo.Cor &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Ano == veiculo.Ano &&
                   Quilometragem == veiculo.Quilometragem &&
                   Foto == veiculo.Foto &&
                   GrupoVeiculos == veiculo.GrupoVeiculos;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}