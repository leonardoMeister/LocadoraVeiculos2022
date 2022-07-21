using System;

namespace LocadoraVeiculos.Dominio.shared
{
    public abstract class EntidadeBase
    {
        public Guid Id;

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

    }
}
