using System;
using System.Collections.Generic;
using System.Text;

namespace VeskoWeb.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Testimonial { get; set; }
        public string ImagePath { get; set; }

        public override void MergeFrom(object other)
        {
            Name = ((Customer)other).Name;
            Testimonial = ((Customer)other).Testimonial;
            Role = ((Customer)other).Role;
            ImagePath = ((Customer)other).ImagePath;

        }
    }
}
