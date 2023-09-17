using Microsoft.EntityFrameworkCore;

namespace MVCTCCAIDPI.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }    

        public DbSet<Pacient> Pacients { get; set; }

        public DbSet<Medic> Medics { get; set; }
    }
}
