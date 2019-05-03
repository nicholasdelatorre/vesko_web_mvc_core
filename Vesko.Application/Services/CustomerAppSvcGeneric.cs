using System;
using System.Collections.Generic;
using System.Text;
using VeskoWeb.Application.GenericService;
using VeskoWeb.DataBase.Context;
using VeskoWeb.DataBase.Repositories;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.Application.Services
{
    public class CustomerAppSvcGeneric : GenericService<Customer>
    {
        public CustomerAppSvcGeneric(AppDbContext context) : base(context)
        {
            repository = new GenericRepository<Customer>(context);
        }

        public override IEnumerable<Customer> FindBy(Customer filter)
        {
            return null;
        }
    }
}
