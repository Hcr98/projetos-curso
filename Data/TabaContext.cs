
using Microsoft.EntityFrameworkCore;
using Taba_Digital.Models;

namespace Taba_Digital.Data
{
    public class TabaContext : DbContext
    {
        public TabaContext(DbContextOptions<TabaContext> opt) : base(opt)
        {
        }
        public DbSet<Aldeia> Aldeias {get; set;}
        public DbSet<Doacoes> Doacoes {get; set;}
        public DbSet<Empresa> Empresas {get; set;}
        public DbSet<Necessidades> Necessidades {get; set;}
        public DbSet<Pessoa> Pessoa {get; set;}
        public DbSet<Solicita> Solicita {get; set;}
    }
}