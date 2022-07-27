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
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
