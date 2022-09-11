using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Api.Models.Sklad_rashod>? Sklad_rashod { get; set; }

        public DbSet<Api.Models.Spr_oplat_sklad>? Spr_oplat_sklad { get; set; }

        public DbSet<Api.Models.Spr_period_filtr>? Spr_period_filtr { get; set; }
    }
}
