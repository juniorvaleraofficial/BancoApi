using Microsoft.EntityFrameworkCore;
using BancoApi.Models;
namespace BancoApi.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<CuentaBancaria> Cuentas { get; set; }
    }
    
}
