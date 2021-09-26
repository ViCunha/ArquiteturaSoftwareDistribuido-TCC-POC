using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Domain.Models;
using Identity.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configure
{
    public class FluentApiCustomer : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //
            builder.ToTable("Customers");

            //
            builder.HasKey(x => x.Id);

            //
            builder.Property(x => x.Name).HasMaxLength(150);

            //
            builder.HasIndex(x => x.Name);
        }
    }
}
