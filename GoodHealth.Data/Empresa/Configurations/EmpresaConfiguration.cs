using GoodHealth.Data.Shared.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Data.Empresa.Configurations
{
    public class EmpresaConfiguration : EntityBaseConfiguration<Domain.Empresa.Entities.Empresa>
    {
        public override void Configure(EntityTypeBuilder<Domain.Empresa.Entities.Empresa> builder)
        {
            base.Configure(builder);

            builder
                .Property(b => b.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder
                .Property(b => b.Endereco)
                .HasColumnName("Endereco")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar(250)")
                .IsRequired();
        }
    }
}
