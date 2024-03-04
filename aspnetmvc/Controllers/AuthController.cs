using aspnetmvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    [HttpGet]
    public IActionResult Signup()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public IActionResult Signup(SignUpViewModel viewModel)
    {
        if (!ModelState.IsValid)
        return View(viewModel);
        
        return RedirectToAction("Index", "Home");
    }

    [Route("/signin")]
    [HttpGet]
    public IActionResult Signin()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public IActionResult Signin(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
    }
}
