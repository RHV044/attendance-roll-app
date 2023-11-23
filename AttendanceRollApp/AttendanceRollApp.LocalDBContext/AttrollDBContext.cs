using AttendanceRollApp.SharedUI.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceRollApp.LocalDBContext
{
    public class AttrollDBContext : DbContext
    {

        // Constructor with no argument is required and it is used when adding/removing migrations from class library
        public AttrollDBContext()
        {
        }
        public AttrollDBContext(DbContextOptions<AttrollDBContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
