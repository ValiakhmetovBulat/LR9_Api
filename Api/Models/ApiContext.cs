using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Models.Sklad;

namespace Api.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Sklad_rashod> Sklad_rashod { get; set; }
        public DbSet<Sklad_rashod_tov> Sklad_rashod_tov { get; set; }
        public DbSet<Sheta> Sheta { get; set; }
        public DbSet<Sklad_dostavki> Sklad_dostavki { get; set; }
        public DbSet<Spr_oplat_sklad> Spr_oplat_sklad { get; set; }
        public DbSet<Spr_period_filtr> Spr_period_filtr { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<Tovary> Tovary { get; set; }
        public DbSet<Zen_roznichnie> Zen_roznichnie { get; set; }
        public DbSet<Prays_zagolovki> Prays_Zagolovki { get; set; }
        public DbSet<Sklad_tov_OSTATKI> Sklad_tov_OSTATKI { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Sklad_prihod> Sklad_prihod { get; set; }
        public DbSet<Sklad_prihod_tov> Sklad_prihod_tov { get; set; }
    }
}
