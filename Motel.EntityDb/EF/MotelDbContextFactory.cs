using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Motel.Utilities.Contains;
using System.IO;

namespace Motel.EntityDb.EF
{
    public class MotelDbContextFactory : IDesignTimeDbContextFactory<MotelDbContext>
    {
        public MotelDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json").Build();

            var connectionstring = configuration.GetConnectionString(SystemContains.MainConnectionString);
            var builder = new DbContextOptionsBuilder<MotelDbContext>();
            builder.UseSqlServer(connectionstring);
         
            return new MotelDbContext(builder.Options);
        }
    }
}
