using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class LoginPlayerUseCase : ILoginPlayerUseCase
    {
        IPlayerCore playerCore;
        IJwtCore jwtCore;
        IPlayerRepository playerRepository;
        private readonly IConfiguration configuration;

        public LoginPlayerUseCase(IPlayerCore playerCore, IJwtCore jwtCore, 
            IPlayerRepository playerRepository, IConfiguration configuration)
        {
            this.playerCore = playerCore;
            this.jwtCore = jwtCore;
            this.playerRepository = playerRepository;
            this.configuration = configuration;
        }

        public string Login(PlayerEntity playerEntity)
        {
            playerCore.ValidatePlayer(playerEntity);
            var foundUser = playerRepository.FindById(playerEntity.PlayerId);
            var passwordDb = foundUser.Password;
            jwtCore.Match(playerEntity.Password, passwordDb);
            string key = configuration["Jwt:Key"];
            string issuer = configuration["Jwt:Issuer"];
            var token = jwtCore.GenerateToken(key, issuer);

            return token;
        }

    }
}
