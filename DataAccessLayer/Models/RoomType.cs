using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RoomType
    {
        //public RoomType()
        //{
        //    Rooms = new List<Room>();
        //}
        public int Id { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }

        ////navigation properties
        //public ICollection<Room> Rooms { get; set; }
    }
}
