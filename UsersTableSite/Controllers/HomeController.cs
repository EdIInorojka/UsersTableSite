using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using UsersTableSite.Models;

namespace UsersTableSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string host = "https://localhost:44331/api/";
        private HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Table()
        {
            List<CompanyModel> companies = new List<CompanyModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(host + "CompanyModels"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    companies = JsonConvert.DeserializeObject<List<CompanyModel>>(apiResponse);
                }
            }
            return View(companies);
        }

        public async Task<IActionResult> AddCompany([FromBody]CompanyModel company)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                "api/products", company);
            response.EnsureSuccessStatusCode();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}