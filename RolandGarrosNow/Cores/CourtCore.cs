using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;

namespace TennisChampionshipMicroservice.Cores
{
    public class CourtCore : ICourtCore
    {
        public void ValidateCourt(CourtEntity courtEntity)
        {
            if (courtEntity == null)
                throw new ArgumentNullException(nameof(courtEntity));
        }
    }
}
