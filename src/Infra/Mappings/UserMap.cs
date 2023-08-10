


using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseMySqlIdentityColumn()
            .HasColumnType("BIGINT");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(80)");
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(30)");
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(14)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(14)");
    }
}