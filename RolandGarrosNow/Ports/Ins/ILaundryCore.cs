using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface ILaundryCore
    {
        public void ValidateLaundry(LaundryEntity laundryEntity);
    }
}
