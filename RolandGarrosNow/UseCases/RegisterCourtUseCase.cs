using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class RegisterCourtUseCase : IRegisterCourtUseCase
    {
        ICourtCore courtCore;
        ICourtRepository courtRepository;

        public RegisterCourtUseCase(ICourtCore courtCore, ICourtRepository courtRepository)
        {
            this.courtCore = courtCore;
            this.courtRepository = courtRepository;
        }
        public CourtEntity RegisterCourt(CourtEntity courtEntity)
        {
            courtCore.ValidateCourt(courtEntity);
            courtRepository.Create(courtEntity);

            return courtEntity;
        }
    }
}
