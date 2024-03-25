using InventarioASP.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InventarioASP.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // creamos la propiedad con DbSet de nuestro modelo Bodega le colocamos "Bodegas" en plural para diferenciarlo en nuestra Base de Datos
        public DbSet <Bodega> Bodegas { get; set; }

        //utilizamos Fluent API. este es un metodo que ya existe en .net para configurarlo miro el video No.24

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
