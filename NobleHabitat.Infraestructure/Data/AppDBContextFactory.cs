using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NobleHabitat.Infraestructure.Data
{
    public class AppDBContextFactory: IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=NobleHabitat;User Id=sa;Password=your_password;");
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
