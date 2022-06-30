using LocadoraVeiculos.Repositorio.shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class IRepositoryPlanoCobranca : IRepository<PlanoCobranca>
    {
        public void Editar(int id, PlanoCobranca registro)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new System.NotImplementedException();
        }

        public void InserirNovo(PlanoCobranca registro)
        {
            throw new System.NotImplementedException();
        }

        public PlanoCobranca SelecionarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public PlanoCobranca SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
