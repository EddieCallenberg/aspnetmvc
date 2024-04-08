using aspnetmvc.ViewModels;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace aspnetmvc.Controllers;

public class AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : Controller
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [HttpGet]
    [Route("/account")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("signin", "Auth");
        var viewModel = new AccountDetailsViewModel();
        viewModel.BasicInfoForm ??= await PopulateBasicInfoFormAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoFormAsync();

        return View(viewModel);
    }

    [HttpPost]
    [Route("/account")]
    public async Task<ActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("signin", "Auth");
        if (ModelState.IsValid)
        {
            if (viewModel.BasicInfoForm != null) { }
            if (viewModel.AddressInfoForm != null) { }
        }
        viewModel.BasicInfoForm ??= await PopulateBasicInfoFormAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoFormAsync();

        return View("Details", viewModel);
    }


        [HttpPost]
    public IActionResult SaveBasicInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.BasicInfoForm))
        {
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Details", viewModel);
    }


    private async Task<BasicInfoFormViewModel> PopulateBasicInfoFormAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new BasicInfoFormViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            Biography = user.Biography,
        };
    }

    private async Task<AddressInfoFormViewModel> PopulateAddressInfoFormAsync()
    {
        return new AddressInfoFormViewModel();
        //{
          //  AddressLine_1 = user!.Address!.StreetName,
            //City = user!.Address!.City,
            //PostalCode = user.Address.PostalCode,
        //};
    }
}
