using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");
            builder.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
            builder.Property(x => x.Cnpj).HasColumnType("varchar(20)");
            builder.Property(x => x.Cpf).HasColumnType("varchar(20)");
            builder.Property(x => x.Endereco).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.TipoCliente).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
