using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class RacketRepository : IRacketRepository
    {
        private readonly RacketDbContext _context;

        public RacketRepository(RacketDbContext context)
        {
            _context = context;
        }

        public RacketEntity Create(RacketEntity racketEntity)
        {
            _context.Rackets.Add(racketEntity);
            _context.SaveChanges();

            return racketEntity;
        }

        public RacketEntity FindRacketById(int id)
        {
            var racket = _context.Rackets.FirstOrDefault(r => r.RacketId == id);

            if (racket == null)
            {
                throw new ArgumentNullException("Racket not found.");
            }

            return racket;
        }

        public void DeleteRacketById(int racketId)
        {
            var racket = _context.Rackets.FirstOrDefault(r => r.RacketId == racketId);

            if (racket != null)
            {
                _context.Rackets.Remove(racket);
                _context.SaveChanges();
            }
        }
    }
}
