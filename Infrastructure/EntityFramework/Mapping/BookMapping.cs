using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Mapping;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> entity)
    {
        entity.HasKey(x => x.Id).HasName("PK_BOOK");

        entity.ToTable("Book");

        entity.Property(x => x.Id).ValueGeneratedOnAdd();

        entity.Property(x => x.Title).IsRequired();

        entity.Property(x => x.Url);
        
        entity.Property(x => x.Price);

        entity.Property(x => x.CreatedAt);

        entity.HasOne(x => x.Author)
            .WithMany(y => y.Books)
            .HasForeignKey(z => z.AuthorId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_BOOK_AUTHOR");

        entity.HasOne(x => x.Category)
            .WithMany(y => y.Books)
            .HasForeignKey(z => z.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_BOOK_CATEGORY");
    }
}