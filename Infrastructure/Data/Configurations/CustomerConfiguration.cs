using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(p => p.Id); // Primary Key
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasMaxLength(256);
            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasMaxLength(256);
            builder.Property(p => p.Gender)
                   .IsRequired()
                   .HasMaxLength(6);
            builder.Property(p => p.EmailId)
                   .IsRequired()
                   .HasMaxLength(256);
        }
    }
}
