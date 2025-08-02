using NobleHabitat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NobleHabitat.Infraestructure.Data
{
    public class AppDBContext : DbContext
    {
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        // Define DbSets for your entities
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Agente> agentes { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Propietario> propietarios { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Inmueble> inmuebles { get; set; }
        public DbSet<Oficina> oficinas { get; set; }
        public DbSet<Zona> zonas { get; set; }
        public DbSet<CaracteristicaInmueble> caracteristicaInmuebles { get; set; }
        public DbSet<Estancia> estancias { get; set; }
        public DbSet<Visita> visitas { get; set; }
        public DbSet<Oferta> ofertas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Agente>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Agente>()
                .HasOne(a => a.Usuario)
                .WithOne(u => u.Agente)
                .HasForeignKey<Agente>(a => a.UsuarioId);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(c => c.UsuarioId);

            modelBuilder.Entity<Inmueble>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Oficina)
                .WithMany(o => o.Inmuebles)
                .HasForeignKey(i => i.OficinaId);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Propietario)
                .WithMany(p => p.Inmuebles)
                .HasForeignKey(i => i.PropietarioId);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Zona)
                .WithMany(z => z.Inmuebles)
                .HasForeignKey(i => i.ZonaId);
            modelBuilder.Entity<Inmueble>()
                .HasOne(i => i.Oferta)
                .WithOne(o => o.Inmueble)
                .HasForeignKey<Oferta>(o => o.InmuebleId);

            modelBuilder.Entity<Estancia>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Estancia>()
                .HasOne(e => e.Inmueble)
                .WithMany(i => i.Estancias)
                .HasForeignKey(e => e.InmuebleId);

            modelBuilder.Entity<Visita>()
                .HasKey(v => v.Id);
            modelBuilder.Entity<Visita>()
                .HasOne(v => v.Inmueble)
                .WithMany(i => i.Visitas)
                .HasForeignKey(v => v.InmuebleId);
            modelBuilder.Entity<Visita>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<CaracteristicaInmueble>()
                .HasKey(ci => ci.Id);
            modelBuilder.Entity<CaracteristicaInmueble>()
                .HasOne(ci => ci.Inmueble)
                .WithMany(i => i.Caracteristicas)
                .HasForeignKey(ci => ci.InmuebleId);

            modelBuilder.Entity<Oferta>()
                .HasKey(o => o.InmuebleId);
            modelBuilder.Entity<Oferta>()
                .HasOne(o => o.Inmueble)
                .WithOne(i => i.Oferta)
                .HasForeignKey<Oferta>(o => o.InmuebleId);


            modelBuilder.Entity<Oficina>()
                .HasKey(o => o.Id);
            //modelBuilder.Entity<Oficina>()
            //    .HasOne(o => o.Zona)
            //    .WithMany(z => z.Oficinas)
            //    .HasForeignKey(o => o.ZonaId);


            modelBuilder.Entity<Zona>()
                .HasKey(z => z.Id);

            modelBuilder.Entity<Propietario>()
                .HasKey(p => p.Id);           
            modelBuilder.Entity<Propietario>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Propietario)
                .HasForeignKey<Propietario>(p => p.UsuarioId);            

        }

    }
}
