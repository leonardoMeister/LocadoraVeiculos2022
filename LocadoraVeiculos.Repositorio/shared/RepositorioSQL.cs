using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.RepositorioProject.shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.Repositorio.shared
{
    public abstract class RepositorioSQL<T> : IRepository<T>
        where T : EntidadeBase
    {
        protected abstract string SqlUpdate { get; }
        protected abstract string SqlDelete { get; }
        protected abstract string SqlInsert { get; }
        protected abstract string SqlSelectAll { get; }
        protected abstract string SqlSelectId { get; }
        protected abstract string SqlExiste { get; } 

        public MapeadorBase<T> Mapeador;

        public RepositorioSQL(MapeadorBase<T> mapeador)
        {
            Mapeador = mapeador;
        }

        public void InserirNovo(T registro)
        {
            int id = DataBase.Insert(SqlInsert, Mapeador.ObtemParametrosRegistro(registro));
            registro._id = id;
        }

        public void Editar(int id, T registro)
        {
            registro._id = id;
            DataBase.Update(SqlUpdate, Mapeador.ObtemParametrosRegistro(registro));
        }

        public bool Existe(int id)
        {
            return DataBase.Exists(SqlExiste, Mapeador.AdicionarParametro("ID", id));
        }

        public void Excluir(int id)
        {
            DataBase.Delete(SqlDelete, Mapeador.AdicionarParametro("ID", id));
        }

        public List<T> SelecionarTodos()
        {
            return DataBase.GetAll(SqlSelectAll, Mapeador.ConverterEmRegistro);
        }

        public T SelecionarPorId(int id)
        {
            return DataBase.Get(SqlSelectId, Mapeador.ConverterEmRegistro, Mapeador.AdicionarParametro("ID", id));
        }

        public T SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            return DataBase.Get(query, Mapeador.ConverterEmRegistro, parameters);
        }
    }
}