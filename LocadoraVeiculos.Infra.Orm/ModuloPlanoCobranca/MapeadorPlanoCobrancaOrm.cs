using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlanoCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.TipoPlano).IsRequired();
            builder.Property(x => x.ValorDia).IsRequired();
            builder.Property(x => x.LimiteKM).IsRequired();
            builder.Property(x => x.ValorKM).IsRequired();

            builder.HasOne(x => x.GrupoVeiculos)
                .WithMany();
        }
    }
}
