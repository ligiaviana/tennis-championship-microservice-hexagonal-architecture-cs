using Microsoft.EntityFrameworkCore;
using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class PlayerDbContext : DbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {
        }

        public DbSet<PlayerEntity> Players { get; set; }
    }
}
