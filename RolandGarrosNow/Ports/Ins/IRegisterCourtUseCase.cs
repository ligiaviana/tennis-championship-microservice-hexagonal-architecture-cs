using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface IRegisterCourtUseCase
    {
        public CourtEntity RegisterCourt(CourtEntity courtEntity);
    }
}
