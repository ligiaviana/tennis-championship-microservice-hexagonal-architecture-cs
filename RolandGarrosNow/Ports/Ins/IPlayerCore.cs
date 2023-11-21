using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface IPlayerCore
    {
        public void ValidatePlayer(PlayerEntity playerEntity);
        public void ValidatePlayerPassword(PlayerEntity playerEntity);
    }
}
