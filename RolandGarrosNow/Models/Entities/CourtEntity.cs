using System.ComponentModel.DataAnnotations;

namespace TennisChampionshipMicroservice.Models.Entities
{
    public class CourtEntity
    {
        [Key]
        public int CourtId { get; set; }
        public bool IsFree { get; set; }
        public bool IsNearRestaurant { get; set; }
        public bool IsNearGym { get; set; }
    }
}
