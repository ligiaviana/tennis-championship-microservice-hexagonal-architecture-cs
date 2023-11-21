using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface ILoginPlayerUseCase
    {
        public string Login(PlayerEntity playerEntity);
    }
}
