using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface IRegisterPlayerUseCase
    {
        public PlayerEntity Register(PlayerEntity playerEntity);
    }
}
