using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Outs
{
    public interface IRacketRepository
    {
        public RacketEntity Create(RacketEntity racketEntity);
        public RacketEntity FindRacketById(int id);
        public void DeleteRacketById(int racketId);
    }
}
