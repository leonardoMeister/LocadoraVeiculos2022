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
            throw new NotImplementedException();
        }

        public void InserirNovo(GrupoVeiculos registro)
        {
            GrupoVeiculos.Add(registro);
        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {            
            return GrupoVeiculos.Find(id);
        }

        public GrupoVeiculos SelecionarPorParametro(GrupoVeiculos registro)
        {
            return GrupoVeiculos.Find(registro.NomeGrupo);
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            return GrupoVeiculos.ToList();
        }
    }
}
