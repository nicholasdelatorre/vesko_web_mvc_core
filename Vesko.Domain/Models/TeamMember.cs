using System;
using System.Collections.Generic;
using System.Text;

namespace VeskoWeb.Domain.Models
{
    public class TeamMember : Entity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twiter { get; set; }

        public override void MergeFrom(object other)
        {
            ImagePath = ((TeamMember)other).ImagePath;
            Name = ((TeamMember)other).Name;
            Role = ((TeamMember)other).Role;
            Facebook = ((TeamMember)other).Facebook;
            Linkedin = ((TeamMember)other).Linkedin;
            Twiter = ((TeamMember)other).Twiter;
        }
    }
}
