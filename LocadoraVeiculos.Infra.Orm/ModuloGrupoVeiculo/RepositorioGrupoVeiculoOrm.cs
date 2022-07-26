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

        public void InserirNovo(GrupoVeiculos registro)
        {
            GrupoVeiculos.Add(registro);
        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public GrupoVeiculos SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
