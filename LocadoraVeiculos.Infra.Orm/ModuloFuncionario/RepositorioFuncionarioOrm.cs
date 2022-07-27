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
            Funcionarios.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Funcionarios.SingleOrDefault(x => x.Id == id);

            Funcionarios.Remove(registro);
        }

        public bool Existe(Guid id)
        {
            var id1 = Funcionarios.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Funcionario registro)
        {
            Funcionarios.Add(registro);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return Funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public Funcionario SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> SelecionarTodos()
        {
            return Funcionarios.ToList();
        }

        public Funcionario SelecionarPorNome(string nome)
        {
            return Funcionarios.SingleOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarPorUsuario(string login)
        {
            return Funcionarios.SingleOrDefault(x => x.Login == login);
        }
    }
}
