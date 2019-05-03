using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.DataBase.Mapping
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> b)
        {
            b.HasKey(p => p.Id);
        }
    }
}
