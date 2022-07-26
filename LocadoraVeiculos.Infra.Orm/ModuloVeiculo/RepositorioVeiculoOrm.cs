using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : IRepositoryVeiculo
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Veiculo> Veiculo;
        public RepositorioVeiculoOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Veiculo = dbContext.Set<Veiculo>();
        }
        public void Editar(Veiculo registro)
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

        public void InserirNovo(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
