using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Booking = new HotelRepository<Booking>(context);
            Branch = new HotelRepository<Branch>(context);
            Customer = new HotelRepository<Customer>(context);
            Room = new HotelRepository<Room>(context);
            RoomType = new HotelRepository<RoomType>(context);
            
        }
        public IHotelRepository<Booking> Booking { get; }

        public IHotelRepository<Branch> Branch { get; }

        public IHotelRepository<Customer> Customer { get; }

        public IHotelRepository<Room> Room { get; }

        public IHotelRepository<RoomType> RoomType { get; }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
