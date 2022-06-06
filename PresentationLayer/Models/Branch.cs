using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
