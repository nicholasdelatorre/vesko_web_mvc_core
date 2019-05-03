using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VeskoWeb.DataBase.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VeskoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.UseSqlServer(connString);
            return new AppDbContext(builder.Options);
        }
    }
}
