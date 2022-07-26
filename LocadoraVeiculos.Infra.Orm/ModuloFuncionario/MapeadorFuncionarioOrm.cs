using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {

            builder.ToTable("TB_FUNCIONARIOS");
            builder.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.DataAdmicao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.TipoPerfil).HasColumnType("varchar(50)").IsRequired();

        }
    }
}
