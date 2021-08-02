using Microsoft.EntityFrameworkCore;
namespace ApiRentaCar.Models
{
    public class RentaCarDbContext : DbContext
    {
        public RentaCarDbContext(DbContextOptions<RentaCarDbContext> data) : base (data){}

        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Vehiculo> Vehiculos {get; set;}
    }
}