using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Booking
    {
        public Booking()
        {
            Rooms = new List<Room>();
        }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set; }

        //navigation properties
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        
        public ICollection<Room> Rooms { get; set; }

    }
}
