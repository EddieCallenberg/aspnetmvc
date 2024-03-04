using aspnetmvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers;

public class AccountController : Controller
{
    [Route("/account")]
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult BasicInfo(AccountDetailsViewModel viewModel)
    {
        return RedirectToAction(nameof(Details));
    }

    [HttpPost]
    public IActionResult AdressInfo(AccountDetailsViewModel viewModel)
    {
        return RedirectToAction(nameof(Details));
    }
}
