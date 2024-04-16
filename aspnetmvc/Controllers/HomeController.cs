using aspnetmvc.ViewModels;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace aspnetmvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("/Subscribe")]
    public IActionResult Subscribe()
    {
        ViewData["Subscribed"] = false;
        return View();
    }

    [Route("/Subscribe")]
    [HttpPost]
    public async Task<IActionResult> Subscribe(NewsletterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();


            var json = JsonConvert.SerializeObject(viewModel);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync($"https://localhost:7233/api/subscribers?email={viewModel.Email}", content);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Subscribed"] = true;
            }
        }


        return RedirectToAction("Index");

    }
}
