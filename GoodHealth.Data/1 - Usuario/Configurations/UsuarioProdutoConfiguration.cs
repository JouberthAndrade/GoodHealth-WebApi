using GoodHealth.Data.Shared.Configuration;
using GoodHealth.Domain.Usuario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHealth.Data.Usuario.Configurations
{
    public class UsuarioProdutoConfiguration : EntityBaseConfiguration<UsuarioProduto>
    {
        public override void Configure(EntityTypeBuilder<UsuarioProduto> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("UsuarioProduto");

            builder
                .HasKey(x => new { x.UsuarioId, x.ProdutoId });

            builder
               .Property(b => b.FlagDia)
               .HasColumnName("FlagDia")
               .HasColumnType("char(2)")
               .IsRequired(true);

            builder
               .Property(b => b.DataInico)
               .HasColumnName("DataInico")
               .HasColumnType("datetime")
                .IsRequired(true);

            builder
                .Property(b => b.DataFim)
                .HasColumnName("DataFim")
                .HasColumnType("datetime")
                .IsRequired(false); ;

            builder
                .HasOne(bc => bc.Usuario)
                .WithMany(b => b.UsuarioProdutos)
                .HasForeignKey(bc => bc.UsuarioId);

            builder
                .HasOne(bc => bc.Produto)
                .WithMany(c => c.UsuarioProdutos)
                .HasForeignKey(bc => bc.ProdutoId);

           

        }

        
    }
}
