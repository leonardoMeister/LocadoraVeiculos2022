using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositoryLocacao
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Locacao> Locacao;
        public RepositorioLocacaoOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Locacao = dbContext.Set<Locacao>();
        }
        public void Editar(Locacao registro)
        {
            Locacao.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Locacao.SingleOrDefault(x => x.Id == id);

            Locacao.Remove(registro);
        }

        public bool Existe(Guid id)
        {
            var id1 = Locacao.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Locacao registro)
        {
            Locacao.Add(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            var lo = Locacao
                .Include(x => x.PlanoCobranca)
                .Include(x => x.Cliente)
                .Include(x => x.Condutores)
                .Include(x => x.GrupoVeiculos)
                .Include(x => x.ListaTaxas)
                .Include(x => x.Veiculo)
                .SingleOrDefault(x => x.Id == id);
            return lo;
        }

        public Locacao SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodos()
        {
            return Locacao.ToList();
        }
    }
}
