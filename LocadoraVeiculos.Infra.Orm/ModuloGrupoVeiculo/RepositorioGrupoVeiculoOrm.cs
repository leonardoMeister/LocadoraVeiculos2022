using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculoOrm : IRepositoryGrupoVeiculos
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<GrupoVeiculos> GrupoVeiculos;
        public RepositorioGrupoVeiculoOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.GrupoVeiculos = dbContext.Set<GrupoVeiculos>();
        }

        public void Editar(GrupoVeiculos registro)
        {
            GrupoVeiculos.Update(registro);
        }

        public void Excluir(Guid id)
        {
            GrupoVeiculos.Remove(SelecionarPorId(id));
        }

        public bool Existe(Guid id)
        {
            var id1 = GrupoVeiculos.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(GrupoVeiculos registro)
        {
            GrupoVeiculos.Add(registro);
        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {
            return GrupoVeiculos.SingleOrDefault(x => x.Id == id);

        }

        public GrupoVeiculos SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            return GrupoVeiculos.ToList();
        }

        public GrupoVeiculos SelecionarPorNome(string nomeGrupo)
        {
            return GrupoVeiculos.SingleOrDefault(x => x.NomeGrupo == nomeGrupo);
        }
    }
}
