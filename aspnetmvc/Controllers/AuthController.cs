using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    public IActionResult Signup()
    {
        return View();
    }
}
