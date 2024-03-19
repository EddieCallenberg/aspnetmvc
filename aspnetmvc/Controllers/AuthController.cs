using aspnetmvc.ViewModels;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers;

public class AuthController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [Route("/signup")]
    [HttpGet]
    public IActionResult Signup()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> Signup(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(viewModel.SignUpForm);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                return RedirectToAction("SignIn", "Auth");
        }

        return View(viewModel);
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
    public async Task<IActionResult> Signin(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.SignInUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)           
            return RedirectToAction("Details", "Account");
        }
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
    }
}
