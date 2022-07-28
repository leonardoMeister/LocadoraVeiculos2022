﻿using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TB_LOCACAO");
            builder.Property(x => x.Id).ValueGeneratedNever().IsUnicode();

            builder.HasOne(x => x.Veiculo).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Conductor).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Cliente).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.GrupoVeiculos).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.PlanoCobranca).WithMany().OnDelete(DeleteBehavior.Cascade);

            //Lista de taxas como faz;
        }
    }
}