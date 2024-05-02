using LightServeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Localization;

namespace LightServeMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string Baseurl = "https://localhost:7128";
        private Customer _customer;

        public HomeController(ILogger<HomeController> logger, Customer customer) : base(customer)
        {

            _customer = customer;
            _logger = logger;
        }

        //public async Task<ActionResult> Index()
        //{
        //    if (_customer.IsAuthorized)
        //    {
        //        List<Cafe> cafes = new List<Cafe>();
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();

        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            string apiUrl = $"api/Cafe/getAllCafes?email={Uri.EscapeDataString(_customer.Email)}";
        //            HttpResponseMessage response = await client.GetAsync(apiUrl);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var cafeResponse = response.Content.ReadAsStringAsync().Result;
        //                cafes = JsonConvert.DeserializeObject<List<Cafe>>(cafeResponse);
        //            }
        //            return View(cafes);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "User");
        //    }
        //}
        //else
        //{
        //    if (_user.Customer.IsAuthorized)
        //    {
        //        List<Menu> menus = new List<Menu>();
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();

        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            string apiUrl = $"api/api/Menu/getAllMenus";
        //            HttpResponseMessage response = await client.GetAsync(apiUrl);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var menuResponse = response.Content.ReadAsStringAsync().Result;
        //                menus = JsonConvert.DeserializeObject<List<Menu>>(menuResponse);
        //            }
        //            return View(menus);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "User");
        //    }
        //}

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
