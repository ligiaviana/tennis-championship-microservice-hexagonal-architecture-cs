using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Outs
{
    public interface IPlayerRepository
    {
        public PlayerEntity Create(PlayerEntity playerEntity);
        public PlayerEntity FindById(int id);
        public void DeletePlayerById(int playerId);
    }
}
