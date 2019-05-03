using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.DataBase.Mapping
{
    public class CustmerMapping : BaseMapping<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.ImagePath).IsRequired();
            builder.Property(c => c.Role).IsRequired();
        }
    }
}
