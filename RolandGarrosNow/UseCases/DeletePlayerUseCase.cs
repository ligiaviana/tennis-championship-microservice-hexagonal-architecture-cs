using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class DeletePlayerUseCase : IDeletePlayerUseCase
    {
        IPlayerRepository playerRepository;
        public DeletePlayerUseCase(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public void DeletePlayer(int playerId)
        {
            var player = playerRepository.FindById(playerId);

            if (player == null)
            {
                throw new ArgumentNullException("Player not found.");
            }

            playerRepository.DeletePlayerById(playerId);
        }
    }
}
