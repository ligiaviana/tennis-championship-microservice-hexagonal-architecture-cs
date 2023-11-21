using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class RegisterRacketUseCase : IRegisterRacketUseCase
    {
        IRacketCore racketCore;
        IRacketRepository racketRepository;

        public RegisterRacketUseCase(IRacketCore racketCore, IRacketRepository racketRepository)
        {
            this.racketCore = racketCore;
            this.racketRepository = racketRepository;
        }

        public RacketEntity RegisterRacket(RacketEntity racketEntity) 
        { 
            racketCore.ValidateRacket(racketEntity);
            racketRepository.Create(racketEntity);

            return racketEntity;
        }
    }
}
