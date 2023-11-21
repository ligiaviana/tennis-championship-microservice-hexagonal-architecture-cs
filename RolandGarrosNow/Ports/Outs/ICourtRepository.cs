using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Outs
{
    public interface ICourtRepository
    {
        public CourtEntity Create(CourtEntity courtEntity);
        public CourtEntity FindCourtById(int id);
        public void DeleteCourtById(int courtId);
    }
}
