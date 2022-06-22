using LocadoraVeiculos.Dominio.shared;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public GrupoVeiculos(string nome, string listacarros)
        {
            Nome = nome;
            ListaCarros = listacarros;
        }

        public string Nome { get; set; }
        public string ListaCarros { get; set; }
    }
}
