using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TB_VEICULO");
            builder.Property(x => x.Id).ValueGeneratedNever().IsUnicode();
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.TipoCombustivel).HasConversion<string>().IsRequired();

            builder.Property(x => x.CapacidadeTanque).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.Quilometragem).IsRequired();
            builder.Property(x => x.Foto);

            builder.HasOne(x => x.GrupoVeiculos)
                .WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
