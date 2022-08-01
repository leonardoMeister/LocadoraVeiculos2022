using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
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
        private DbSet<PlanoCobranca> cobrancas;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioPlanoCobrancaOrm(LocadoraVeiculosDbContext dbContext)
        {
            cobrancas = dbContext.Set<PlanoCobranca>();
            this.dbContext = dbContext;
        }

        public void InserirNovo(PlanoCobranca novoRegistro)
        {
            cobrancas.Add(novoRegistro);
        }

        public void Editar(PlanoCobranca registro)
        {
            cobrancas.Update(registro);
        }

        public void Excluir(Guid id)
        {
            PlanoCobranca registro = cobrancas.SingleOrDefault(x => x.Id == id);

            cobrancas.Remove(registro);
        }

        public PlanoCobranca SelecionarPorId(Guid id)
        {
            return cobrancas.SingleOrDefault(x => x.Id == id);
        }

        public List<PlanoCobranca> SelecionarTodos(bool incluirDisciplinaEhMateria = false)
        {
            if (incluirDisciplinaEhMateria)
                return cobrancas
                    .Include(x => x.GrupoVeiculos)
                    .ToList();

            return cobrancas.ToList();
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            return cobrancas.ToList();
        }

        public bool Existe(Guid id)
        {
            var id1 = cobrancas.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public PlanoCobranca SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<PlanoCobranca> SelecionarPlanoCobrancaPorGrupoVeiculo(GrupoVeiculos grupoVeiculo)
        {
            return cobrancas.Where(x => x.GrupoVeiculos.Id == grupoVeiculo.Id).ToList();
        }
    }
}
