

using System.Collections.Generic;
using VeskoWeb.Application.GenericService;
using VeskoWeb.DataBase.Context;
using VeskoWeb.DataBase.Repositories;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.Application.Services
{
    public class TeamMemberAppSvcGeneric : GenericService<TeamMember>
    {
        public TeamMemberAppSvcGeneric(AppDbContext context) : base(context)
        {
            repository = new GenericRepository<TeamMember>(context);
        }

        public override IEnumerable<TeamMember> FindBy(TeamMember filter)
        {
            return null;
        }
    }
}
