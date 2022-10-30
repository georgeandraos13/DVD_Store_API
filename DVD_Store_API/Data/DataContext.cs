using DVD_Store_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DVD_Store_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorActress>()
                .HasKey(pc => pc.Id);
            modelBuilder.Entity<Customer>()
                .HasKey(pc => pc.Id);
            modelBuilder.Entity<Movie>()
                .HasKey(pc => pc.Id);
            modelBuilder.Entity<MovieActorActress>()
                .HasKey(pc => pc.Id);
            modelBuilder.Entity<Rent>()
                .HasKey(pc => pc.Id);
            modelBuilder.Entity<MovieActorActress>()
                .HasOne(pc => pc.Movie)
                .WithMany(p => p.MoviesActorsActresses)
                .HasForeignKey(c => c.MovidId);
            modelBuilder.Entity<MovieActorActress>()
                .HasOne(pc => pc.ActorActress)
                .WithMany(p => p.MoviesActorsActresses)
                .HasForeignKey(c => c.ActorActressId);
            modelBuilder.Entity<Rent>()
                .HasOne(pc => pc.Customer)
                .WithMany(p => p.Rents)
                .HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Rent>()
                .HasOne(pc => pc.Movie)
                .WithMany(p => p.Rents)
                .HasForeignKey(c => c.MovidId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ActorActress> ActorsActresses { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActorActress> MoviesActorsActresses { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
