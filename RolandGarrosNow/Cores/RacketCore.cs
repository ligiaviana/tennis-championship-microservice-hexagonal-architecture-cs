using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;

namespace TennisChampionshipMicroservice.Cores
{
    public class RacketCore : IRacketCore
    {
        public void ValidateRacket(RacketEntity racketEntity)
        {
            if (racketEntity == null)
                throw new ArgumentNullException(nameof(racketEntity));

            if (string.IsNullOrEmpty(racketEntity.OwnerName))
                throw new ArgumentException("OwnerName should be informed");

            if (string.IsNullOrEmpty(racketEntity.Name))
                throw new ArgumentException("Racket Name should be informed");
        }
    }
}
