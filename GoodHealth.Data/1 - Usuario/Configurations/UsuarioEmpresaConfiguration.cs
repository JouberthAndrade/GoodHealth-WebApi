using GoodHealth.Data.Shared.Configuration;
using GoodHealth.Domain.Usuario.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHealth.Usuario.Configurations
{
    public class UsuarioEmpresaConfiguration : EntityBaseConfiguration<UsuarioEmpresa>
    {
        public override void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("UsuarioEmpresa");

            builder
                .HasKey(x => new { x.UsuarioId, x.EmpresaId, x.Id });

            builder.Metadata
                .FindNavigation(nameof(UsuarioEmpresa.Usuario))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(UsuarioEmpresa.Empresa))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
