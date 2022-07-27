using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositoryCliente
    {
        private LocadoraVeiculosDbContext dbContext;
        DbSet<Cliente> Clientes;
        public RepositorioClienteOrm(LocadoraVeiculosDbContext db)
        {
            this.dbContext = db;
            this.Clientes = dbContext.Set<Cliente>();            
        }

        public void Editar(Cliente registro)
        {
            Clientes.Update(registro);
        }

        public void Excluir(Guid id)
        {
            var registro = Clientes.SingleOrDefault(x => x.Id == id);

            Clientes.Remove(registro);
        }

        public bool Existe(Guid id)
        {
            var id1 = Clientes.SingleOrDefault(x => x.Id == id);
            if (id1 != null)
            {
                return true;
            }

            return false;
        }

        public void InserirNovo(Cliente registro)
        {
            this.Clientes.Add(registro);
            
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return Clientes.SingleOrDefault(x => x.Id == id);
        }

        public Cliente SelecionarPorParametro(string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodos()
        {
            return this.Clientes.ToList();
        }
    }
}
