using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class DeleteRacketUseCase : IDeleteRacketUseCase
    {
        IRacketRepository racketRepository;
        public DeleteRacketUseCase(IRacketRepository racketRepository)
        {
            this.racketRepository = racketRepository;
        }

        public void DeleteRacket(int racketId)
        {
            var racket = racketRepository.FindRacketById(racketId);

            if (racket == null)
            {
                throw new ArgumentNullException("Racket not found.");
            }

            racketRepository.DeleteRacketById(racketId);
        }
    }
}
