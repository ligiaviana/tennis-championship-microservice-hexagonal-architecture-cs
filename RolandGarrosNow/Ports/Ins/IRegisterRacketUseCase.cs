using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface IRegisterRacketUseCase
    {
        public RacketEntity RegisterRacket(RacketEntity racketEntity);
    }
}
