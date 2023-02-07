using FBTarjetas.Models;
using Microsoft.EntityFrameworkCore;

namespace FBTarjetas
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
