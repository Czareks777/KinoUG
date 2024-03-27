using Microsoft.EntityFrameworkCore;

namespace KinoUG.Server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}
