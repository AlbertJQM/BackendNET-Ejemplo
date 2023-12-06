using BackendNET_Ejemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendNET_Ejemplo
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Curso> Curso { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
    }
}
