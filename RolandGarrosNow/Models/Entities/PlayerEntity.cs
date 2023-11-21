using System.ComponentModel.DataAnnotations;

namespace TennisChampionshipMicroservice.Models.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int RankingPosition { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
