using aspnetmvc.ViewModels;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers;

public class AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : Controller
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [Route("/account")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("signin", "Auth");

        var userEntity = await _userManager.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel()
        {
            User = userEntity!
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SaveData(AccountDetailsViewModel viewModel)
    {
        var result = await _userManager.UpdateAsync(viewModel.User);
        if (!result.Succeeded) 
        {
            ModelState.AddModelError("SomethingWentWrong", "Somethign went wrong when saving the data");
            ViewData["ErrorMessage"] = "Unable to save data";
        }

        return RedirectToAction("Details", "Account", viewModel);9
    }

    [HttpPost]
    public IActionResult AdressInfo(AccountDetailsViewModel viewModel)
    {
        return View(viewModel);
    }
}
