using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalInmobiliario.Models;

namespace Pc2_Progra.Data;

public class ApplicationDbContext : IdentityDbContext
{
    // Hereda de IdentityDbContext para incluir usuarios, roles, claims, etc.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Tablas personalizadas
    public DbSet<Inmueble> Inmuebles { get; set; }
    public DbSet<Visita> Visitas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    // Configuración adicional (semillas, restricciones, etc.)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Código único en Inmueble
        modelBuilder.Entity<Inmueble>()
            .HasIndex(i => i.Codigo)
            .IsUnique();

        // Semilla de datos
        modelBuilder.Entity<Inmueble>().HasData(
            new Inmueble
            {
                Id = 1,
                Codigo = "DEP001",
                Titulo = "Departamento céntrico",
                Tipo = "Departamento",
                Ciudad = "Lima",
                Direccion = "Av. Principal 123",
                Dormitorios = 3,
                Banos = 2,
                MetrosCuadrados = 90,
                Precio = 120000,
                Activo = true
            },
            new Inmueble
            {
                Id = 2,
                Codigo = "CASA001",
                Titulo = "Casa en la playa",
                Tipo = "Casa",
                Ciudad = "Chiclayo",
                Direccion = "Calle Sol 456",
                Dormitorios = 4,
                Banos = 3,
                MetrosCuadrados = 200,
                Precio = 250000,
                Activo = true
            },
            new Inmueble
            {
                Id = 3,
                Codigo = "OFI001",
                Titulo = "Oficina moderna",
                Tipo = "Oficina",
                Ciudad = "Trujillo",
                Direccion = "Av. Negocios 789",
                Dormitorios = 0,
                Banos = 2,
                MetrosCuadrados = 70,
                Precio = 95000,
                Activo = true
            }
        );
    }
}

