using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase
    {
        public Devolucao(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public Devolucao Clone()
        {
            return MemberwiseClone() as Devolucao;
        }
        public override bool Equals(object obj)
        {
            return obj is Devolucao devolucao &&
                   Id == devolucao.Id &&
                   Nome == devolucao.Nome;
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
