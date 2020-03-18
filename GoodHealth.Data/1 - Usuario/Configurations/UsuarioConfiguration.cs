using GoodHealth.Data.Shared.Configuration;
using GoodHealth.Domain.Usuario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHealth.Data.Usuario.Configurations
{
    public class UsuarioConfiguration : EntityBaseConfiguration<Domain.Usuario.Entities.Usuario>
    {
        public override void Configure(EntityTypeBuilder<Domain.Usuario.Entities.Usuario> builder)
        {
            base.Configure(builder);

            builder
                .Property(b => b.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(b => b.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(b => b.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(b => b.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(b => b.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
            .Property(b => b.TipoUsuario)
            .HasColumnName("Perfil")
            .HasColumnType("char(1)")
            .IsRequired();


            builder
                .HasOne(x => x.Empresa)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(x => x.Token);
        }
    }
}
