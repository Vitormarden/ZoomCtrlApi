using Microsoft.EntityFrameworkCore;
using ZooCtrlAPI.Models;

namespace ZooCtrlAPI.Data
{
    public class Context : DbContext
    {
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Filo> Filo { get; set; }
        public DbSet<Zona_Zoo> zona_Zoo { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
            )
        {
            object value = optionsBuilder.UseSqlServer("Data Source=MARDONHA-NOT;Initial Catalog=ZooCtrl;Integrated Security=True");
        }
    }
}
