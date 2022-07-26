using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm
{
    public class GeradorLocadoraDbContext : DbContext
    {
        public DbSet<Taxas> Taxas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<GrupoVeiculos> GrupoVeiculos { get; set; }
        public DbSet<Condutores> Condutores { get; set; }
        public DbSet<PlanoCobranca> PlanoCobranca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var con = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=TesteORM;Integrated Security=True";
            optionsBuilder.UseSqlServer(con);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taxas>(entidade =>
            {
                entidade.ToTable("TB_TAXAS");
                entidade.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
                entidade.Property(x => x.Tipo).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Valor);
            });

            modelBuilder.Entity<Funcionario>(entidade =>
            {
                entidade.ToTable("TB_FUNCIONARIOS");
                entidade.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
                entidade.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Login).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Senha).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Salario).IsRequired();
                entidade.Property(x => x.DataAdmicao).HasColumnType("datetime").IsRequired();
                entidade.Property(x => x.TipoPerfil).HasColumnType("varchar(50)").IsRequired();

            });

           

            modelBuilder.Entity<GrupoVeiculos>(entidade =>
            {
                entidade.ToTable("TB_GRUPOVEICULOS");
                entidade.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
                entidade.Property(x => x.NomeGrupo).HasColumnType("varchar(100)").IsRequired();
            });

            modelBuilder.Entity<Condutores>(entidade =>
            {
                entidade.ToTable("TB_CONDUTORES");
                entidade.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
                entidade.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Cpf).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Endereco).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Telefone).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.Cnh).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.ValidadeCnh).HasColumnType("varchar(100)").IsRequired();
            });

            modelBuilder.Entity<PlanoCobranca>(entidade =>
            {
                entidade.ToTable("TB_PLANOCOBRANCA");
                entidade.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
                entidade.Property(x => x.TipoPlano).HasColumnType("varchar(100)").IsRequired();
                entidade.Property(x => x.ValorDia).IsRequired();
                entidade.Property(x => x.LimiteKM).IsRequired();
                entidade.Property(x => x.ValorKM).IsRequired();
                entidade.HasOne(x => x.GrupoVeiculos);
            });

        }
    }

}
