using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LightServeMVC.Models;
using System.Net.Http.Headers;
using LightServeMVC.Models.ViewModels;


namespace LightServeMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly string Baseurl = "https://localhost:7082/api/Menu/";
        private User _user;

        public MenuController(User user) : base(user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int menuId)
        {
            Menu viewModel = new Menu();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string apiUrl = $"getMenuById?menuId={menuId}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var menuResponse = await response.Content.ReadAsStringAsync();
                    viewModel = JsonConvert.DeserializeObject<Menu>(menuResponse);
                }
            }

            return View(viewModel);
        }
    }
}
