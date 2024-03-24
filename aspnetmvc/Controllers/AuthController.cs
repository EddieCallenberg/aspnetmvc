using aspnetmvc.ViewModels;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace aspnetmvc.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AdressService adressService) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AdressService _adressService;

    [Route("/signup")]
    [HttpGet]
    public IActionResult Signup()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> Signup(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.SignUpForm.EmailAddress);
            if (exists)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email address already exists.");
                ViewData["ErrorMessage"] = "User with the same email address already exists.";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.SignUpForm.FirstName,
                LastName = viewModel.SignUpForm.LastName,
                Email = viewModel.SignUpForm.EmailAddress,
                UserName = viewModel.SignUpForm.EmailAddress
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.SignUpForm.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Signin");
            }
        }

        return View(viewModel);
    }

    [Route("/signin")]
    [HttpGet]
    public IActionResult Signin()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> Signin(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Form.EmailAddress, viewModel.Form.Password, viewModel.Form.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }

        }
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
    }

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

}



