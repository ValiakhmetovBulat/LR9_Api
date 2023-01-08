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

        public DbSet<User> users { get; set; }
        public DbSet<Sklad_rashod> sklad_rashod { get; set; }
        public DbSet<Sklad_rashod_tov> sklad_rashod_tov { get; set; }
        public DbSet<Sheta> sheta { get; set; }
        public DbSet<Sklad_dostavki> Sklad_dostavki { get; set; }
        public DbSet<Spr_oplat_sklad> spr_oplat_sklad { get; set; }
        public DbSet<Spr_period_filtr> Spr_period_filtr { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<Tovary> tovary { get; set; }
        public DbSet<Zen> zen { get; set; }
        public DbSet<Prays_zagolovki> Prays_Zagolovki { get; set; }
        public DbSet<Sklad_tov_OSTATKI> sklad_tov_ostatki { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Sklad_prihod> sklad_prihod { get; set; }
        public DbSet<Sklad_prihod_tov> sklad_prihod_tov { get; set; }
    }
}
