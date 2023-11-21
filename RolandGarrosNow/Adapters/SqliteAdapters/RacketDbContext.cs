using Microsoft.EntityFrameworkCore;
using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class RacketDbContext : DbContext
    {
        public RacketDbContext(DbContextOptions<RacketDbContext> options) : base(options) 
        { 
        }

        public DbSet<RacketEntity> Rackets { get; set; }
    }
}
