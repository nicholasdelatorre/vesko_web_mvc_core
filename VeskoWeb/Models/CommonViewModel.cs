using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.Models
{
    public class CommonViewModel
    {
        public IEnumerable<TeamMember> Team { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public Email Email { get; set; }
        public string StatusModel { get; set; }

        public CommonViewModel()
        {
            StatusModel = "default";
        }
    }
}
