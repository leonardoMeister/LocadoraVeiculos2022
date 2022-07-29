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
            Taxas.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Taxas.SingleOrDefault(x => x.Id == id);

            Taxas.Remove(registro);
        }

        public bool Existe(Guid id)
        {
            var id1 = Taxas.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Taxas registro)
        {
            Taxas.Add(registro);
        }

        public Taxas SelecionarPorId(Guid id)
        {
            return Taxas.SingleOrDefault(x => x.Id == id);
        }

        public Taxas SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Taxas> SelecionarTodos()
        {
            return Taxas.ToList();
        }

        public Taxas SelecionarPorDescricao(string descricao)
        {
            return Taxas.SingleOrDefault(x => x.Descricao == descricao);
        }
    }
}
