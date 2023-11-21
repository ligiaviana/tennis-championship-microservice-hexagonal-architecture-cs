using Microsoft.EntityFrameworkCore;
using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class LaundryDbContext : DbContext 
    {
        public LaundryDbContext(DbContextOptions<LaundryDbContext> options) : base(options) 
        { 
        }
        public DbSet<LaundryEntity> Laundry { get; set; }
    }
}
