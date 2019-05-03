using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VeskoWeb.Domain.Models;

namespace VeskoWeb.DataBase.Context
{
    public class AppDbContext : DbContext
    {     
        #region DBSets
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = Assembly.GetAssembly(typeof(AppDbContext)).GetTypes()
                .Where(
                    w => w.AssemblyQualifiedName.Contains("VeskoWeb.DataBase.Context.Mapping")
                    && !w.IsNestedPrivate
                    && !w.IsAbstract
                    && w.IsPublic);
            foreach (var t in types)
            {
                dynamic o = Activator.CreateInstance(t);
                modelBuilder.ApplyConfiguration(o);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
