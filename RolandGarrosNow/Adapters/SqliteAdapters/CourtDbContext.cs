using Microsoft.EntityFrameworkCore;
using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class CourtDbContext : DbContext
    {
        public CourtDbContext(DbContextOptions<CourtDbContext> options) : base(options)
        { 
        }
        public DbSet<CourtEntity> Courts { get; set; }
    }
}
