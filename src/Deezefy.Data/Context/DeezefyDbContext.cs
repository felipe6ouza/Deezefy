using Deezefy.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Deezefy.Data.Context
{
    public class DeezefyDbContext : DbContext
    {

        public DbSet<Album> Albuns { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Ouvinte> Ouvintes { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DeezefyDbContext(DbContextOptions<DeezefyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(50)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeezefyDbContext).Assembly);
            
            modelBuilder.Entity<Usuario>()
               .HasKey(u => u.Email);

            modelBuilder.Entity<Artista>().ToTable("Artistas");
            modelBuilder.Entity<Ouvinte>().ToTable("Ouvintes");

            modelBuilder.Entity<Artista>()
               .HasBaseType<Usuario>();

            modelBuilder.Entity<Ouvinte>()
              .HasBaseType<Usuario>();

            modelBuilder.Entity<Musica>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Playlist>()
                .HasKey(p => p.Nome);

            modelBuilder.Entity<Album>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Perfil>()
                            .HasKey(p => p.Id);

            modelBuilder.Entity<Genero>()
                            .HasKey(g => g.Nome);

            modelBuilder.Entity<Ouvinte>()
            .HasOne(p => p.Perfil)
            .WithOne(o => o.Ouvinte)
            .HasForeignKey<Perfil>(p => p.OuvinteEmail);

            modelBuilder.Entity<Album>()
               .HasOne(a => a.Artista)
               .WithMany(a => a.AlbumsLancados)
               .HasForeignKey(a => a.ArtistaEmail);

            modelBuilder.Entity<Evento>()
             .HasOne(e => e.Organizador)
             .WithMany(o => o.EventosOrganizados)
             .HasForeignKey(e => e.EmailOrganizador);

            modelBuilder.Entity<Usuario>().Ignore(u => u.Idade);
            modelBuilder.Entity<Playlist>().Ignore(p => p.nOuvintes);


        }
    }
}
