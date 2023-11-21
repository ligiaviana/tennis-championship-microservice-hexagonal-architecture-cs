using TennisChampionshipMicroservice.Ports.Outs;

namespace TennisChampionshipMicroservice.UseCases
{
    public class DeleteLaundryUseCase : IDeleteLaundryUseCase
    {
        ILaundryRepository laundryRepository;
        public DeleteLaundryUseCase(ILaundryRepository laundryRepository)
        {
            this.laundryRepository = laundryRepository;
        }

        public void DeleteLaundry(int bagId)
        {
            var laundry = laundryRepository.FindByBagId(bagId);

            if (laundry == null)
            {
                throw new ArgumentNullException("BagId not found.");
            }

            laundryRepository.DeleteLaundryById(bagId);
        }
    }
}
