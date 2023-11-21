using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class CourtRepository : ICourtRepository
    {
        private readonly CourtDbContext _context;

        public CourtRepository(CourtDbContext context)
        {
            _context = context;
        }

        public CourtEntity Create(CourtEntity courtEntity)
        {
            _context.Courts.Add(courtEntity);
            _context.SaveChanges();

            return courtEntity;
        }

        public CourtEntity FindCourtById(int id)
        {
            var court = _context.Courts.FirstOrDefault(c => c.CourtId == id);

            if (court == null)
            {
                throw new ArgumentNullException("Court not found.");
            }

            return court;
        }

        public void DeleteCourtById(int courtId)
        {
            var court = _context.Courts.FirstOrDefault(c => c.CourtId == courtId);

            if (court != null)
            {
                _context.Courts.Remove(court);
                _context.SaveChanges();
            }
        }
    }
}
