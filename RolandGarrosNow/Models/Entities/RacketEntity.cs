using System.ComponentModel.DataAnnotations;

namespace TennisChampionshipMicroservice.Models.Entities
{
    public class RacketEntity
    {
        [Key]
        public int RacketId { get; set; }
        public int PlayerId { get; set; }
        public string OwnerName { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double StringTension { get; set; }
        public string MainColor { get; set; }
        public string MainComposition { get; set; }

    }
}
