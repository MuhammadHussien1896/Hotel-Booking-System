using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
