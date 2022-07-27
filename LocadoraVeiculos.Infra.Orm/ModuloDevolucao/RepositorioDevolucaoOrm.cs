using LocadoraVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : IRepositoryDevolucao
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Devolucao> Devolucao;
        public RepositorioDevolucaoOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Devolucao = dbContext.Set<Devolucao>();
        }
        public void Editar(Devolucao registro)
        {
            Devolucao.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Devolucao.SingleOrDefault(x => x.Id == id);

            Devolucao.Remove(registro);
        }

        public bool Existe(Guid id)
        {
            var id1 = Devolucao.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Devolucao registro)
        {
            Devolucao.Add(registro);
        }

        public Devolucao SelecionarPorId(Guid id)
        {
            return Devolucao.SingleOrDefault(x => x.Id == id);
        }

        public Devolucao SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Devolucao> SelecionarTodos()
        {
            return Devolucao.ToList();
        }
    }
}
