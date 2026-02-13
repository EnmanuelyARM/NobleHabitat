using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NobleHabitat.Infrastructure.Data
{
    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NobleHabitatDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
);
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
