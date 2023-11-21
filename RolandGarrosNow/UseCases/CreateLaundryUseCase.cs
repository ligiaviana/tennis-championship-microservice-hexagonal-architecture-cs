using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;
using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class CreateLaundryUseCase : ICreateLaundryUseCase
    {
        ILaundryCore laundryCore;
        ILaundryRepository laundryRepository;

        public CreateLaundryUseCase(ILaundryCore laundryCore, ILaundryRepository laundryRepository)
        {
            this.laundryCore = laundryCore;
            this.laundryRepository = laundryRepository;
        }

        public LaundryEntity CreateLaundry(LaundryEntity laundryEntity)
        {
            laundryCore.ValidateLaundry(laundryEntity);
            laundryRepository.Create(laundryEntity);

            return laundryEntity;
        }
    }
}
