using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RentalCar.Models
{
    public class RentalCarContext : DbContext
    {
        public RentalCarContext(DbContextOptions<RentalCarContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Combustivel> Combustiveis { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Locacao> Locacoes { get; set; }
    }
}