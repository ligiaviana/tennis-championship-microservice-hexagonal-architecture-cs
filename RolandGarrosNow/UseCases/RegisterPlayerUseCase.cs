using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class RegisterPlayerUseCase : IRegisterPlayerUseCase
    {
        IPlayerCore playerCore;
        IPlayerRepository playerRepository;
        IPlayerLogCore playerLogCore;

        public RegisterPlayerUseCase(IPlayerCore playerCore, IPlayerRepository playerRepository, 
            IPlayerLogCore playerLogCore)
        {
            this.playerCore = playerCore;
            this.playerRepository = playerRepository;
            this.playerLogCore = playerLogCore;
        }

        public PlayerEntity Register(PlayerEntity playerEntity)
        {
            playerCore.ValidatePlayer(playerEntity);
            playerCore.ValidatePlayerPassword(playerEntity);
            playerLogCore.Log(playerEntity.Email);
            playerRepository.Create(playerEntity);

            return playerEntity;
        } 
    }
}
