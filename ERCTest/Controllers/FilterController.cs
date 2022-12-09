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
    public class FilterController : Controller
    {
        HttpClient httpClient;

        public FilterController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            httpClient = new HttpClient(clientHandler);
        }

        public async Task<IActionResult> FilterByResidentsOnly()
        {
            var viewModel = await httpClient.GetFromJsonAsync<PersonalAccountViewModel>("https://localhost:44302/api/BLL/GetByResidentsOnly");

            return View("Index", viewModel);
        }

        public async Task<IActionResult> FilterByStartDate(PersonalAccountViewModel viewModel)
        {
            using var response = await httpClient.PostAsJsonAsync("https://localhost:44302/api/BLL/GetByStartDate", viewModel);
            PersonalAccountViewModel responseViewModel = await response.Content.ReadFromJsonAsync<PersonalAccountViewModel>();

            return View("Index", responseViewModel);
        }

        public async Task<IActionResult> FilterByNameResidents(PersonalAccountViewModel viewModel)
        {
            using var response = await httpClient.PostAsJsonAsync("https://localhost:44302/api/BLL/GetByResidentsName", viewModel);
            PersonalAccountViewModel responseViewModel = await response.Content.ReadFromJsonAsync<PersonalAccountViewModel>();

            return View("Index", responseViewModel);
        }

        public async Task<IActionResult> FilterByAdress(PersonalAccountViewModel viewModel)
        {
            using var response = await httpClient.PostAsJsonAsync("https://localhost:44302/api/BLL/GetByAdress", viewModel);
            PersonalAccountViewModel responseViewModel = await response.Content.ReadFromJsonAsync<PersonalAccountViewModel>();

            return View("Index", responseViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
