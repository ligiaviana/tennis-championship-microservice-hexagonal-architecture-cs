using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;

namespace TennisChampionshipMicroservice.Cores
{
    public class PlayerCore : IPlayerCore
    {
        public void ValidatePlayer(PlayerEntity playerEntity)
        {
            if (playerEntity == null)
                throw new ArgumentNullException(nameof(playerEntity));

            if (string.IsNullOrEmpty(playerEntity.Name))
                throw new ArgumentException("Name should be informed");

            if (string.IsNullOrEmpty(playerEntity.Email))
                throw new ArgumentException("Email should be informed");

            if (string.IsNullOrEmpty(playerEntity.Password))
                throw new ArgumentException("Password should be informed");
        }

        public void ValidatePlayerPassword(PlayerEntity playerEntity)
        {
            if (playerEntity == null)
                throw new ArgumentNullException(nameof(playerEntity));

            string password = playerEntity.Password;

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("The password cannot be empty.", nameof(playerEntity));

            if (password.Length < 8)
                throw new ArgumentException("The password must have at least 8 characters.", nameof(playerEntity));

            if (!password.Any(char.IsUpper))
                throw new ArgumentException("The password must have at least one capital letter.", nameof(playerEntity));

            if (!password.Any(char.IsLower))
                throw new ArgumentException("The Password must have at least one lower case letter.", nameof(playerEntity));

            if (!password.Any(char.IsDigit))
                throw new ArgumentException("The password must have at least one digit.", nameof(playerEntity));

            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                throw new ArgumentException("The Password must have at least one special character.", nameof(playerEntity));

        }
    }
}
