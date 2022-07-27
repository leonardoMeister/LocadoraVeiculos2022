using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase
    {
        public Locacao(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public Locacao Clone()
        {
            return MemberwiseClone() as Locacao;
        }
        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id == locacao.Id &&
                   Nome == locacao.Nome;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }
    }
}
