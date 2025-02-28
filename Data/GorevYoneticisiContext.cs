namespace GorevYoneticisi.Data
{
    using GorevYoneticisi.Models;
    using Microsoft.EntityFrameworkCore;

    public class GorevYoneticisiContext : DbContext
    {
        public GorevYoneticisiContext(DbContextOptions<GorevYoneticisiContext> options)
            : base(options)
        {
        }

        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .HasMany(k => k.Gorevler)
                .WithOne(g => g.Kullanici)
                .HasForeignKey(g => g.KullaniciId);
        }
    }
}
