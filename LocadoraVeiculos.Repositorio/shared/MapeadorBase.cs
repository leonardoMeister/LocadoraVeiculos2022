using LocadoraVeiculos.Dominio.shared;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.shared
{
    public abstract class MapeadorBase<T> where T : EntidadeBase
    {
        public abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);

        public abstract T ConverterEmRegistro(IDataReader dataReader);

        public Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}