using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.Adapters.SqliteAdapters
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerDbContext _context;

        public PlayerRepository(PlayerDbContext context)
        {
            _context = context;
        }

        public PlayerEntity Create(PlayerEntity playerEntity)
        {
            _context.Players.Add(playerEntity);
            _context.SaveChanges();

            return playerEntity;
        }

        public PlayerEntity FindById(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == id);

            if (player == null)
            {
                throw new ArgumentNullException("Player not found");
            }
            return player;
        }

        public void DeletePlayerById(int playerId)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);

            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
        }
    }
}
