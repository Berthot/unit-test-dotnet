using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasKey(x => x.Id).HasName("PK_CATEGORY");

        entity.ToTable("Category");

        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.Name).IsRequired();
    }
}