using LocadoraVeiculos.Dominio.ModuloLocacao;
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

            builder.HasOne(x => x.Veiculo).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Condutores).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Cliente).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.GrupoVeiculos).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PlanoCobranca).WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.DataLocacao);
            builder.Property(x => x.DataEstimadaDevolucao);
            builder.Property(x => x.DataRealDaDevolucao);
            builder.Property(x => x.QuilometragemInicial);
            builder.Property(x => x.QuilometragemFinal);
            builder.Property(x => x.StatusDevolucao).IsRequired();
            builder.Property(x => x.NivelTanqueEnumInicio).HasConversion<string>();
            builder.Property(x => x.NivelTanqueEnumDevolucao).HasConversion<string>();
        }
    }
}
