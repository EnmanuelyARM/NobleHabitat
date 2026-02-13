using NobleHabitat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NobleHabitat.Domain.Models;

namespace NobleHabitat.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        // Define DbSets for your entities
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<CaracteristicaInmueble> CaracteristicaInmuebles { get; set; }
        public DbSet<Estancia> Estancias { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
            // Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            // Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Agente
            modelBuilder.Entity<Agente>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Agente>()
                .HasOne(a => a.Usuario)
                .WithOne(u => u.Agente)
                .HasForeignKey<Agente>(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Agente>()
                .HasOne(a => a.Oficina)
                .WithMany(o => o.Agentes)
                .HasForeignKey(a => a.OficinaId)
                .OnDelete(DeleteBehavior.Cascade); // Agentes se eliminan si se elimina la oficina

            // Propietario
            modelBuilder.Entity<Propietario>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Propietario>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Propietario)
                .HasForeignKey<Propietario>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Oficina
            modelBuilder.Entity<Oficina>()
                .HasKey(o => o.Id);

            // Zona
            modelBuilder.Entity<Zona>()
                .HasKey(z => z.Id);

            // Inmueble
            modelBuilder.Entity<Inmueble>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Oficina)
                .WithMany(o => o.Inmuebles)
                .HasForeignKey(i => i.OficinaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Propietario)
                .WithMany(p => p.Inmuebles)
                .HasForeignKey(i => i.PropietarioId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Zona)
                .WithMany(z => z.Inmuebles)
                .HasForeignKey(i => i.ZonaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Oferta)
                .WithOne(o => o.Inmueble)
                .HasForeignKey<Oferta>(o => o.InmuebleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Estancia
            modelBuilder.Entity<Estancia>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Estancia>()
                .HasOne(e => e.Inmueble)
                .WithMany(i => i.Estancias)
                .HasForeignKey(e => e.InmuebleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Característica
            modelBuilder.Entity<CaracteristicaInmueble>()
                .HasKey(ci => ci.Id);
            modelBuilder.Entity<CaracteristicaInmueble>()
                .HasOne(ci => ci.Inmueble)
                .WithMany(i => i.Caracteristicas)
                .HasForeignKey(ci => ci.InmuebleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Visita
            modelBuilder.Entity<Visita>()
                .HasKey(v => v.Id);
            modelBuilder.Entity<Visita>()
                .HasOne(v => v.Inmueble)
                .WithMany(i => i.Visitas)
                .HasForeignKey(v => v.InmuebleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Visita>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Visita>()
                .HasOne(v => v.Agente)
                .WithMany(a => a.Visitas)
                .HasForeignKey(v => v.AgenteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Oferta
            modelBuilder.Entity<Oferta>()
                .HasKey(o => o.InmuebleId);
            modelBuilder.Entity<Oferta>()
                .HasOne(o => o.Inmueble)
                .WithOne(i => i.Oferta)
                .HasForeignKey<Oferta>(o => o.InmuebleId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Oferta>()
            .Property(o => o.PrecioAlquiler)
            .HasPrecision(18, 2);
            modelBuilder.Entity<Oferta>()
                .Property(o => o.PrecioVenta)
                .HasPrecision(18, 2);

        }

    }
}
