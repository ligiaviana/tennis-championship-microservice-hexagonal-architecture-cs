using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class DeleteCourtUseCase : IDeleteCourtUseCase
    {
        ICourtRepository courtRepository;

        public DeleteCourtUseCase(ICourtRepository courtRepository)
        {
            this.courtRepository = courtRepository;
        }

        public void DeleteCourt(int courtId)
        {
            var court = courtRepository.FindCourtById(courtId);

            if (court == null)
            {
                throw new ArgumentNullException("Court not found.");
            }

            courtRepository.DeleteCourtById(courtId);
        }
    }
}
