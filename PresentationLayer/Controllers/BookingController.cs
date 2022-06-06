using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class BookingController : Controller
    {
        private readonly string apiBaseUrl;
        public BookingController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("WebApiUrl");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> NewBooking()
        {
            NewBookingViewModel model = new NewBookingViewModel();
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(apiBaseUrl + "/GetBranches");
            var branches = await response.Content.ReadFromJsonAsync<List<Branch>>();
            if (response.IsSuccessStatusCode)
            {
                model.Branches = branches?.Select(b => new SelectListItem() { Value = b.Id.ToString(), Text = b.Location });
            }
            
            response = await client.GetAsync(apiBaseUrl + "/GetRoomTypes");
            var roomTypes = await response.Content.ReadFromJsonAsync<List<RoomType>>();
            if (response.IsSuccessStatusCode)
            {
                model.RoomTypes = roomTypes?.Select(b => new SelectListItem() { Value = b.Id.ToString(), Text = b.Type });
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> NewBooking(NewBookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                Booking booking = new Booking();
                booking.BookingDate = model.BookingDate.ToDateTime(TimeOnly.MinValue);
                booking.Customer = new Customer() { FullName = model.CustomerName, Id = model.CustomerId };
                Room room = new Room() { BranchId = model.BranchId, TypeId = model.RoomTypeId };
                booking.Rooms.Add(room);
                using HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiBaseUrl + "/NewBooking", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }

                
            }
            else
            {
                return View(model);
            }
        }
         
    }
}
