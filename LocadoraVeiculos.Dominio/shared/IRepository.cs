using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Repositorio.shared
{
    public interface IRepository<T> where T : EntidadeBase
    {
        public void InserirNovo(T registro);

        public void Editar(T registro);

        public bool Existe(Guid id);

        public void Excluir(Guid id);

        public T SelecionarPorParametro(T registro);

        public List<T> SelecionarTodos();

        public T SelecionarPorId(Guid id);
    }
}