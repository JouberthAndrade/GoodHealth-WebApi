using GoodHealth.Data.Shared.Configuration;
using GoodHealth.Domain.Produto.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GoodHealth.Data.Pruduto.Configurations
{
    public class ProdutoConfiguration : EntityBaseConfiguration<Domain.Produto.Entities.Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {

            base.Configure(builder);

            builder
                .Property(b => b.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(b => b.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .Ignore(x => x.Classe);
        }
    }
}
