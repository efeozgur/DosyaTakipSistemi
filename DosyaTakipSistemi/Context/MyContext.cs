using DosyaTakipSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace DosyaTakipSistemi.Context
{
    public class MyContext : DbContext
    {
        public DbSet<DosyaModel> Dosyalar { get; set; }
        public DbSet<TarafModel> Taraflar { get; set; }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarafModel>()
              .Property(t => t.TarafTur)
              .HasConversion<string>();
        }
    }
}
