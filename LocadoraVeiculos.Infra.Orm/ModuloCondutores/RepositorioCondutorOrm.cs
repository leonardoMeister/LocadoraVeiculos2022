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
            Condutores.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Condutores.SingleOrDefault(x => x.Id == id);

            Condutores.Remove(registro);
        }

        public bool Existe(Guid id)
        {
            var id1 = Condutores.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Condutores registro)
        {
            Condutores.Add(registro);
        }

        public Condutores SelecionarPorId(Guid id)
        {
            return Condutores.SingleOrDefault(x => x.Id == id);
        }

        public Condutores SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Condutores> SelecionarTodos()
        {
            return Condutores.ToList();
        }
    }
}
