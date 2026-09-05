using DepoYonetim.Models;
using Microsoft.EntityFrameworkCore;

namespace DepoYonetim.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Fabrika> Fabrikalar => Set<Fabrika>();
    public DbSet<Depo> Depolar => Set<Depo>();
    public DbSet<Raf> Raflar => Set<Raf>();
    public DbSet<Urun> Urunler => Set<Urun>();
    public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
    public DbSet<RafStok> RafStoklari => Set<RafStok>();
    public DbSet<StokHareketi> StokHareketleri => Set<StokHareketi>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RafStok>()
            .HasKey(rs => new { rs.RafId, rs.UrunId });

        modelBuilder.Entity<StokHareketi>()
            .HasOne(h => h.Raf).WithMany()
            .HasForeignKey(h => h.RafId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}