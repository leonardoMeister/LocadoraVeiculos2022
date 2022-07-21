using LocadoraVeiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm
{
    public class GeradorLocadoraDbContext: DbContext
    {
        public DbSet<Taxas> Taxas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var con = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=TesteORM;Integrated Security=True";
            optionsBuilder.UseSqlServer(con);   

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Taxas>(entidade =>
            {
                entidade.ToTable("TB_TAXAS");
                entidade.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
                entidade.Property(x => x.Tipo).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Valor);
            });
        }
    }

}
