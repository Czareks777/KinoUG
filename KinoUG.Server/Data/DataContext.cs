using KinoUG.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KinoUG.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
       public DbSet<User> Users { get; set; } 
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserTickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
             
        }

        //Many to Many 
    }
}
