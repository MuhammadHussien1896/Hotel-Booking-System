using DataAccessLayer.Models;
using DataAccessLayer.Unit_Of_Work;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Services : ControllerBase
    {
        private readonly IUnitOfWork dbcontext;

        public Services(IUnitOfWork dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer(string id, string fullName)
        {
            Customer customer = new Customer() { Id = id, FullName = fullName };
            dbcontext.Customer.Create(customer);
            dbcontext.Complete();
            return Ok();
        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(string customerId)
        {
            var customer = dbcontext.Customer.GetBy(c => c.Id == customerId,null);
            if(customer != null)
            {
                return Ok(customer);
            }
            return BadRequest();
        }
        
        [HttpGet("GetBranches")]
        public IActionResult GetBranches()
        {
            var branches = dbcontext.Branch.GetAll(null);
            
            if (branches != null)
            {
                return Ok(branches);
            }
            return BadRequest();
        }
        [HttpGet("GetRooms")]
        public IActionResult GetRooms(int branchId)
        {
            var rooms = dbcontext.Room.GetAllBy(r => r.BranchId == branchId,new string[] {"RoomType"});
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return BadRequest();
        }
        [HttpGet("GetRoomTypes")]
        public IActionResult GetRoomTypes()
        {
            var roomTypes = dbcontext.RoomType.GetAll(null);
            if (roomTypes != null)
            {
                return Ok(roomTypes);
            }
            return BadRequest();
        }
        [HttpPost("NewBooking")]
        public IActionResult NewBooking(Booking booking)
        {
            var customer = dbcontext.Customer.GetBy(c => c.Id == booking.Customer.Id, null);
            var availableRooms = new List<Room>();
            foreach (var item in booking.Rooms)
            {
                var room = dbcontext.Room.GetBy(r => r.IsAvailable && r.TypeId == item.TypeId, null);
                if (room != null)
                {
                    availableRooms.Add(room);
                }
                else
                {
                    return BadRequest();
                }
            }
            if (customer != null)
            {
                booking.Customer = customer;
                foreach (var item in availableRooms)
                {
                    item.IsBooked = true;
                    customer.Rooms.Add(item);
                }
            }else
            {
                Customer newCustomer = new Customer() { Id = booking.Customer.Id,FullName = booking.Customer.FullName };
                dbcontext.Customer.Create(newCustomer);
                booking.Customer = newCustomer;
                foreach (var item in availableRooms)
                {
                    item.IsBooked = true;
                    newCustomer.Rooms.Add(item);
                }
            }
            dbcontext.Booking.Create(booking);
            dbcontext.Complete();
            return Ok();
        }

    }
}
