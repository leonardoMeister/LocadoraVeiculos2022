using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace LocadoraVeiculos.Repositorio.shared
{
    public abstract class RepositorioSQL<T> : IRepository<T>
        where T : EntidadeBase
    {
        private readonly string enderecoBanco;

        public RepositorioSQL()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            enderecoBanco = configuracao.GetConnectionString("SqlServer");
        }

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
            DataBase.Insert(SqlInsert, Mapeador.ObtemParametrosRegistro(registro));
        }

        public void Editar(Guid id, T registro)
        {
            registro._id = id;
            DataBase.Update(SqlUpdate, Mapeador.ObtemParametrosRegistro(registro));
        }

        public bool Existe(Guid id)
        {
            return DataBase.Exists(SqlExiste, Mapeador.AdicionarParametro("ID", id));
        }

        public void Excluir(Guid id)
        {
            DataBase.Delete(SqlDelete, Mapeador.AdicionarParametro("ID", id));
        }

        public List<T> SelecionarTodos()
        {
            return DataBase.GetAll(SqlSelectAll, Mapeador.ConverterEmRegistro);
        }

        public T SelecionarPorId(Guid id)
        {
            return DataBase.Get(SqlSelectId, Mapeador.ConverterEmRegistro, Mapeador.AdicionarParametro("ID", id));
        }

        public T SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            return DataBase.Get(query, Mapeador.ConverterEmRegistro, parameters);
        }
    }
}