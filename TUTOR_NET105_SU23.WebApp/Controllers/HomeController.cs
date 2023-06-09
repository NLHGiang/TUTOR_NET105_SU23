using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient _client = new HttpClient();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/[action]/{status:int}")]
        public async Task<ActionResult> UserList(int status)
        {
            // Call API
            var respone = await _client.GetAsync($"https://localhost:7206/api/Users/GetAll/{status}");
            var jsonString = await respone.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return View("UserList", data);
        }
    }
}