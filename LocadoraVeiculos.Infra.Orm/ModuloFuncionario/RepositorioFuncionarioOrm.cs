using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : IRepositoryFuncionario
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Funcionario> Funcionarios;
        public RepositorioFuncionarioOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Funcionarios = dbContext.Set<Funcionario>();
        }
        public void Editar(Funcionario registro)
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

        public void InserirNovo(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Funcionario SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
