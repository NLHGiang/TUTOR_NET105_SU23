using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.WebApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient _client = new HttpClient();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]/{status:int}")]
        public async Task<ActionResult> UserList(int status)
        {
            // Call API
            var respone = await _client.GetAsync($"https://localhost:7206/api/Users/GetAll/{status}");
            var jsonString = await respone.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return View("UserList", data);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult> UserDetails(Guid id)
        {
            // Call API
            var respone = await _client.GetAsync($"https://localhost:7206/api/Users/{id}");
            var jsonString = await respone.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<User>(jsonString);
            return View("UserDetails", data);
        }

        [HttpGet]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(User? request)
        {
            // Kiem tra HTTPMethod = GET -> View()
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                return View("Create");
            }

            // HTTPMethod = POST ->
            // GAN GIA TRI CHO THUOC TINH
            request.Id = Guid.NewGuid();
            request.Status = 1;

            var content = System.Text.Json.JsonSerializer.Serialize(request);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Call API
            var postResult = await _client.PostAsync($"https://localhost:7206/api/Users", bodyContent);

            var postResultV2 = await _client.PostAsJsonAsync<User>($"https://localhost:7206/api/Users", request);

            // Kiem tra ket qua API tra ve
            if (postResult.IsSuccessStatusCode)
            {
                return RedirectToAction("UserList", "Home", new { status = 1 });
            }

            return View("Create", request);
        }

        [HttpGet]
        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<ActionResult> Update(Guid id, User? request)
        {
            // Kiem tra HTTPMethod = GET -> lay du lieu tu GetById -> View()
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                var respone = await _client.GetAsync($"https://localhost:7206/api/Users/{id}");
                var jsonString = await respone.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<User>(jsonString);

                return View("Update", data);
            }

            // Call API
            var postResult = await _client.PutAsJsonAsync($"https://localhost:7206/api/Users/{id}", request);

            // Kiem tra ket qua API tra ve
            if (postResult.IsSuccessStatusCode)
            {
                return RedirectToAction("UserList", "Home", new { status = 1 });
            }

            return View("Update", request);
        }

        [Route("[action]/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Call API
            var postResult = await _client.DeleteAsync($"https://localhost:7206/api/Users/{id}");

            return RedirectToAction("UserList", "Home", new { status = 1 });
        }
    }
}