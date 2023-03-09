using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Mapping;

public class AuthorMapping : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> entity)
    {
        entity.HasKey(x => x.Id).HasName("PK_AUTHOR");
        
        entity.ToTable("Author");

        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.Name).IsRequired();
        
    }
}