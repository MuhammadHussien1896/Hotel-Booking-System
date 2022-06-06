using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Branch
    {
        public Branch()
        {
            Rooms = new List<Room>();
        }
        public int Id { get; set; }
        public string Location { get; set; }

        //navigation properties
        public ICollection<Room> Rooms { get; set; }
    }
}
