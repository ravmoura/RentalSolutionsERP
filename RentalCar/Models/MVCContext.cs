using System.Data.Entity;


namespace RentalCar.Models
{
    public class MVCContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
    }
}
