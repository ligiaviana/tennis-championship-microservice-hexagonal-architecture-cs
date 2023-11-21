using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface IRacketCore
    {
        public void ValidateRacket(RacketEntity racketEntity);
    }
}
