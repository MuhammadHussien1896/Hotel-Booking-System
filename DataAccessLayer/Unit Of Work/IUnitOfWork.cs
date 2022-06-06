using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        public IHotelRepository<Booking> Booking { get; }
        public IHotelRepository<Branch> Branch { get; }
        public IHotelRepository<Customer> Customer { get; }
        public IHotelRepository<Room> Room { get; }
        public IHotelRepository<RoomType> RoomType { get; }
        public void Complete();
    }
}
