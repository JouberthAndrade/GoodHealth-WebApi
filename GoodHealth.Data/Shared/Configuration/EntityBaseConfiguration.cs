using GoodHealth.Shared.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GoodHealth.Data.Shared.Configuration
{
    public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(b => b.Ativo)
                .HasColumnType("bit")
                .HasColumnName("Ativo")
                .HasDefaultValue(0);

            builder
               .Property(b => b.DeletedDate)
               .HasColumnType("datetime")
               .HasColumnName("DeletedDate")
               .IsRequired(false);

            builder.Ignore(a => a.Notifications);
        }
    }
}
