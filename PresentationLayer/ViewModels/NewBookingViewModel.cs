using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationLayer.Models;

namespace PresentationLayer.ViewModels
{
    public class NewBookingViewModel
    {
        public IEnumerable<SelectListItem> Branches { get; set; }
        public int BranchId { get; set; }
        public IEnumerable<SelectListItem> RoomTypes { get; set; }
        public int RoomTypeId { get; set; }
        public Room Room { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public DateOnly BookingDate { get; set; }
    }
}
