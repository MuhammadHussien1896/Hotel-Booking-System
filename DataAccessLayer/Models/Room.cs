using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Room
    {
        public Room()
        {
            IsAvailable = true;
            Customers = new List<Customer>();
            Bookings = new List<Booking>();
        }
        public int Id { get; set; }
        public bool IsBooked { get; set; }
        public bool IsAvailable { get; set; }

        //navigation properties
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        [ForeignKey("RoomType")]
        public int TypeId { get; set; }
        public RoomType RoomType { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
