using System.ComponentModel.DataAnnotations;

namespace ASPMind.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SeriesNumber { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Status { get; set; }



    }
}
