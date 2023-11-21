using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface ICourtCore
    {
        public void ValidateCourt(CourtEntity courtEntity);
    }
}
