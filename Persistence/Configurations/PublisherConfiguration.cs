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
    internal sealed class PublisherConfiguration : IEntityTypeConfiguration<Publisher>

    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable(nameof(Publisher));

            builder.HasKey(publisher => publisher.Id);

            builder.Property(publisher => publisher.Id).ValueGeneratedOnAdd();

            builder.Property(publisher => publisher.Name).HasMaxLength(150);

            builder.Property(publisher => publisher.CreatedOnUtc).IsRequired();

            builder.Property(publisher => publisher.LastModifiedOnUtc).IsRequired();
        }
    }
}
