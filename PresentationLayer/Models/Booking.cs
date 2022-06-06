using System.Collections.Generic;

namespace PresentationLayer.Models
{
    public class Booking
    {
        public Booking()
        {
            Rooms = new List<Room>();
        }
        public DateTime BookingDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
