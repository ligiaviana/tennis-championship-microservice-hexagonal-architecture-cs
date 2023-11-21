using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface ICreateLaundryUseCase
    {
        public LaundryEntity CreateLaundry(LaundryEntity laundryEntity);
    }
}
