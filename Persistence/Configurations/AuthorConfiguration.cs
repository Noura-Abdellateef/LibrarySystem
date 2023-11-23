using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Configurations
{
    internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));

            builder.HasKey(author => author.Id);

            builder.Property(author => author.Id).ValueGeneratedOnAdd();

            builder.Property(author => author.Name).HasMaxLength(150);

            builder.Property(author => author.CreatedOnUtc).IsRequired();

            builder.Property(author => author.LastModifiedOnUtc).IsRequired();

            builder.HasMany(author => author.Books)
               .WithOne()
               .HasForeignKey(book =>book.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
