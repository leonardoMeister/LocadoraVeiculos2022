using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloTaxas
{
    public class RepositorioTaxaOrm : IRepositoryTaxas
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Taxas> Taxas;
        public RepositorioTaxaOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Taxas = dbContext.Set<Taxas>();
        }
        public void Editar(Taxas registro)
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

        public void InserirNovo(Taxas registro)
        {
            throw new NotImplementedException();
        }

        public Taxas SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Taxas SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Taxas> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
