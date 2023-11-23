using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.HasKey(book => book.Id);

            builder.Property(book => book.Id).ValueGeneratedOnAdd();

            builder.Property(book => book.Title).HasMaxLength(250);

            builder.Property(book => book.CreatedOnUtc).IsRequired();

            builder.Property(book => book.LastModifiedOnUtc).IsRequired();
        }
    }
}
