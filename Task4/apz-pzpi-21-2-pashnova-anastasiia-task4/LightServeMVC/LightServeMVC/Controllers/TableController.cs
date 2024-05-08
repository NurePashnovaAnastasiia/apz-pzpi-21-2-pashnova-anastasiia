using LightServeMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LightServeMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : BaseController
    {
        private readonly string Baseurl = "https://localhost:7082/";
        private User _user;

        public TableController(User user) : base(user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<ActionResult> GetTables(int cafeId)
        {
            if (_user.IsAuthorized)
            {
                List<Table> tables = new List<Table>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string apiUrl = $"api/Table/getAllTables?cafeId={cafeId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var tableResponse = await response.Content.ReadAsStringAsync();
                        tables = JsonConvert.DeserializeObject<List<Table>>(tableResponse);
                    }

                    return View(tables);
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
