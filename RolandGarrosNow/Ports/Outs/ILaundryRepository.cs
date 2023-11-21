using TennisChampionshipMicroservice.Models.Entities;

namespace TennisChampionshipMicroservice.Ports.Outs
{
    public interface ILaundryRepository
    {
        public LaundryEntity Create(LaundryEntity laundryEntity);
        public LaundryEntity FindByBagId(int id);
        public void DeleteLaundryById(int bagId);

    }
}
