using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
