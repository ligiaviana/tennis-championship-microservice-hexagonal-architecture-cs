using TennisChampionshipMicroservice.Models.Entities;
using TennisChampionshipMicroservice.Ports.Ins;

namespace TennisChampionshipMicroservice.Cores
{
    public class LaundryCore : ILaundryCore
    {
        public void ValidateLaundry(LaundryEntity laundryEntity)
        {
            if (laundryEntity == null)
                throw new ArgumentNullException("BagId / PricePerKilogram / EntryDate should be informed");
        }
    }
}
