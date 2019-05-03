using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.DataBase.Context
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this AppDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>().
                GetAppliedMigrations()
                .Select(s => s.MigrationId);
            var total = context.GetService<IMigrationsAssembly>().
                Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }

        public static void InitialSeed(this AppDbContext context)
        {


            #region Inserts Team
            if (!context.TeamMembers.Any())
            {
                context.Add(new TeamMember
                {
                    Name = "Daniel Watrous",
                    ImagePath = "team/team-1.jpg",
                    Facebook = "#",
                    Linkedin = "#",
                    Twiter = "#",
                    Role = "CEO"
                });

                context.Add(new TeamMember
                {
                    Name = "Sara Smith",
                    ImagePath = "team/team-2.jpg",
                    Facebook = "#",
                    Linkedin = "#",
                    Twiter = "#",
                    Role = "Co-Founder"
                });

                context.Add(new TeamMember
                {
                    Name = "Steve Mike",
                    ImagePath = "team/team-3.jpg",
                    Facebook = "#",
                    Linkedin = "#",
                    Twiter = "#",
                    Role = "Sr. Developer"
                });

                context.Add(new TeamMember
                {
                    Name = "Robert Hinay",
                    ImagePath = "team/team-4.jpg",
                    Facebook = "#",
                    Linkedin = "#",
                    Twiter = "#",
                    Role = "Sr. Designer"
                });


                context.Add(new TeamMember
                {
                    Name = "Mike Tera",
                    ImagePath = "team/team-5.jpg",
                    Facebook = "#",
                    Linkedin = "#",
                    Twiter = "#",
                    Role = "Sales"
                });

                context.SaveChanges();
            }
            #endregion


            #region Inserts Customer
            if (!context.TeamMembers.Any())
            {
                context.Add(new Customer
                {
                    Name = "Daniel Watrous",
                    ImagePath = "client/client-1.jpg",
                    Role = "CEO & Founder - Google",
                    Testimonial = "Duis sodales sed leo ut iaculis. Mauris sit amet nisi venenatis, iaculis libero vitae, elementum lacus. Aenean quis felis dui. Morbi ut accumsan tortor. Pellentesque eu ante turpis. Fusce molestie luctus placerat. Nullam tincidunt enim justo, nec dictum ipsum egestas vel."
                });

                context.Add(new Customer
                {
                    Name = "Johan Mathew",
                    ImagePath = "client/client-2.jpg",
                    Role = "CEO & Founder - Yahoo",
                    Testimonial = "Duis sodales sed leo ut iaculis. Mauris sit amet nisi venenatis, iaculis libero vitae, elementum lacus. Aenean quis felis dui. Morbi ut accumsan tortor. Pellentesque eu ante turpis. Fusce molestie luctus placerat. Nullam tincidunt enim justo, nec dictum ipsum egestas vel."
                });


                context.Add(new Customer
                {
                    Name = "Sara Smith",
                    ImagePath = "client/client-3.jpg",
                    Role = "CEO & Founder - Amazon",
                    Testimonial = "Duis sodales sed leo ut iaculis. Mauris sit amet nisi venenatis, iaculis libero vitae, elementum lacus. Aenean quis felis dui. Morbi ut accumsan tortor. Pellentesque eu ante turpis. Fusce molestie luctus placerat. Nullam tincidunt enim justo, nec dictum ipsum egestas vel."
                });

                context.SaveChanges();
            }
            #endregion
        }
    }
}