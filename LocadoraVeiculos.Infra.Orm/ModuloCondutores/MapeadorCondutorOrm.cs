using LocadoraVeiculos.Dominio.ModuloCondutores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloCondutores
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutores>
    {
        public void Configure(EntityTypeBuilder<Condutores> builder)
        {
            builder.ToTable("TB_CONDUTORES");
            builder.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cnh).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.ValidadeCnh).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
