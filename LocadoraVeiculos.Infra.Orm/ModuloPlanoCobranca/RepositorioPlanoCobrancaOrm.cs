using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : IRepositoryPlanoCobranca
    {

        private LocadoraVeiculosDbContext dbContext;
        DbSet<PlanoCobranca> PlanoCobrancas;
        public RepositorioPlanoCobrancaOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.PlanoCobrancas = dbContext.Set<PlanoCobranca>();
        }
        public void Editar(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Guid id)
        {
            throw new NotImplementedException();
        }

        public void InserirNovo(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public PlanoCobranca SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public PlanoCobranca SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
