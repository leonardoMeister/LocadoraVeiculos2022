using LocadoraVeiculos.Dominio.shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.Repositorio.shared
{
    public interface IRepository<T> where T : EntidadeBase
    {
        public void InserirNovo(T registro);

        public void Editar(int id, T registro);

        public bool Existe(int id);

        public void Excluir(int id);

        public List<T> SelecionarTodos();

        public T SelecionarPorId(int id);
    }
}