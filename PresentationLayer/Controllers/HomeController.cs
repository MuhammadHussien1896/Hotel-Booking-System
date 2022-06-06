using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiBaseUrl;

        public HomeController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("WebApiUrl");
        }
        public IActionResult Index()
        {
            return RedirectToAction("DisplayAllRooms");
        }

        [HttpGet]
        public IActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch(Branch b)
        {
            if (ModelState.IsValid)
            {


                using HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiBaseUrl + "/createbranch", content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content(response.StatusCode.ToString());
                }
            }
            else
            {
                return View(b);
            }

        }
        [HttpGet]
        public async Task<IActionResult> DisplayAllRooms()
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(apiBaseUrl + "/GetBranches");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var branches = await response.Content.ReadFromJsonAsync<List<Branch>>();
                ReportViewModel model = new ReportViewModel()
                {
                    Branches = branches?.Select(b => new SelectListItem() { Value = b.Id.ToString(), Text = b.Location })
                };
                return View(model);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> DisplayAllRooms(ReportViewModel model)
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(apiBaseUrl + "/GetRooms"+"?branchId="+model.BranchId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                model.Rooms = await response.Content.ReadFromJsonAsync<List<Room>>();
            }
            else
            {
                return NotFound();
            }
            response = await client.GetAsync(apiBaseUrl + "/GetBranches");
            var branches = response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<List<Branch>>() : null;
            model.Branches = branches?.Select(b => new SelectListItem() { Value = b.Id.ToString(), Text = b.Location });
            return View(model);

        }
        
    }
}