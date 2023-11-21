using System.ComponentModel.DataAnnotations;

namespace TennisChampionshipMicroservice.Models.Entities
{
    public class LaundryEntity
    {
        [Key]
        public int BagId { get; set; }
        public double PricePerKilogram { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
