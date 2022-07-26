using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloCondutores
{
    public class RepositorioCondutorOrm : IRepositoryCondutores
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Condutores> Condutores;
        public RepositorioCondutorOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Condutores = dbContext.Set<Condutores>();
        }
        public void Editar(Condutores registro)
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

        public void InserirNovo(Condutores registro)
        {
            throw new NotImplementedException();
        }

        public Condutores SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Condutores SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Condutores> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
