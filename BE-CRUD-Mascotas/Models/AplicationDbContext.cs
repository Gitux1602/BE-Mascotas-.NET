using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BE_CRUD_Mascotas.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base (options)
        { 
        }
        public DbSet<Mascota> Mascotas { get; set; } //Esto se hace por la cantidad de tablas que tienes
    }
}
