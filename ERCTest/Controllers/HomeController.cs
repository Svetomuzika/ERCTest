using ERCTest.Models;
using ERCTest.DAL.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ERCTest.DAL.Models.ViewModels;
using ERCTest.DAL.Models.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace ERCTest.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient;

        public HomeController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler() 
            { 
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } 
            };

            httpClient = new HttpClient(clientHandler);
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await httpClient.GetFromJsonAsync<PersonalAccountViewModel>("https://localhost:44302/api/DAL/GetAll");

            return View(viewModel);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(PersonalAccount personalAccount)
        {
            await httpClient.PostAsJsonAsync("https://localhost:44302/api/DAL/Create", personalAccount);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(int id, PersonalAccountViewModel viewModel)
        {
            var updateAcc = viewModel.PersonalAccounts.Where(x => x.Id == id).SingleOrDefault();
            await httpClient.PutAsJsonAsync("https://localhost:44302/api/DAL/Update", updateAcc);

            return NoContent();
        }

        public async Task<IActionResult> DeleteAccount(int id)
        {
            await httpClient.DeleteAsync($"https://localhost:44302/api/DAL/Delete/{id}");

            return RedirectToAction("Index");
        }
    }
}
