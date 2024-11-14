using Microsoft.EntityFrameworkCore;
using Sistema_Reportes_Caidas.Domain.Entities;

namespace Sistema_Reportes_Caidas.Infrastructure.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        
        public DbSet<Sistema> Sistemas { get; set; }
    }
}
