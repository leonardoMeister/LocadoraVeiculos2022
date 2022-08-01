using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
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
            Veiculo.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Veiculo.SingleOrDefault(x => x.Id == id);

            Veiculo.Remove(registro);
        }
        public List<Veiculo> SelecionarVeiculosPorGrupoVeiculos(GrupoVeiculos grupoVeiculo)
        {
            return Veiculo.Where(x => x.GrupoVeiculos.Id == grupoVeiculo.Id).ToList();
        }

        public bool Existe(Guid id)
        {
            var id1 = Veiculo.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Veiculo registro)
        {
            Veiculo.Add(registro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return Veiculo.SingleOrDefault(x => x.Id == id);
        }

        public Veiculo SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodos()
        {
            return Veiculo.ToList();
        }
    }
}
