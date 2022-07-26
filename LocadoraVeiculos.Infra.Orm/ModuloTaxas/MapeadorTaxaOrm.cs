using LocadoraVeiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloTaxas
{
    public class MapeadorTaxaOrm : IEntityTypeConfiguration<Taxas>
    {
        public void Configure(EntityTypeBuilder<Taxas> builder)
        {

            builder.ToTable("TB_TAXAS");
            builder.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
            builder.Property(x => x.Tipo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Valor);
           
        }
    }
}
