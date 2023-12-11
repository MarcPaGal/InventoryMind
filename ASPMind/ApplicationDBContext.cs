using ASPMind.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPMind
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }
    }
}
