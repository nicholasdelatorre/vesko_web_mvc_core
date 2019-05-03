using System;
using System.Collections.Generic;
using System.Text;

namespace VeskoWeb.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InactivateDate { get; set; }
        public abstract void MergeFrom(object other);

        public Entity()
        {
            IsActive = true;
        }
    }
}
