using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NobleHabitat.Infraestructure.Data
{
    public class AppDBContextFactory: IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NobleHabitatDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
);
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
