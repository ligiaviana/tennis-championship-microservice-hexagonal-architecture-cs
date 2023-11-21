using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class LaundryRepository : ILaundryRepository
    {
        private readonly LaundryDbContext _context;

        public LaundryRepository(LaundryDbContext context)
        {
            _context = context;
        }

        public LaundryEntity Create(LaundryEntity laundryEntity)
        {
            _context.Laundry.Add(laundryEntity);
            _context.SaveChanges();

            return laundryEntity;
        }

        public LaundryEntity FindByBagId(int id)
        {
            var laundry = _context.Laundry.FirstOrDefault(l => l.BagId == id);

            if (laundry == null)
            {
                throw new ArgumentNullException("Bag not found.");
            }

            return laundry;
        }
        public void DeleteLaundryById(int bagId)
        {
            var laundry = _context.Laundry.FirstOrDefault(l => l.BagId == bagId);

            if (laundry != null)
            {
                _context.Laundry.Remove(laundry);
                _context.SaveChanges();
            }
        }
    }
}
