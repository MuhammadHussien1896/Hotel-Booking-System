using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationLayer.Models;

namespace PresentationLayer.ViewModels
{
    public class ReportViewModel
    {
        public ReportViewModel()
        {
            Rooms = new List<Room>();
        }
        public IEnumerable<SelectListItem> Branches { get; set; }
        public int BranchId { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
