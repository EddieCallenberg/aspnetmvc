using aspnetmvc.ViewModels;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace aspnetmvc.Controllers;

public class AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, DataContext context) : Controller
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _context = context;

    [HttpGet]
    [Route("/account")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("signin", "Auth");
        var viewModel = new AccountDetailsViewModel();
        viewModel.BasicInfoForm ??= await PopulateBasicInfoFormAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoFormAsync();
        viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();

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
            if (viewModel.BasicInfoForm != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfoForm.FirstName;
                    user.LastName = viewModel.BasicInfoForm.LastName;
                    user.Email = viewModel.BasicInfoForm.Email;
                    user.PhoneNumber = viewModel.BasicInfoForm.PhoneNumber;
                    user.Biography = viewModel.BasicInfoForm.Biography;

                    await _userManager.UpdateAsync(user);
                }
            }
            if (viewModel.AddressInfoForm != null)
            {
                var user = await _userManager.GetUserAsync(User);

                var newAddress = new AddressEntity
                {
                    StreetName = viewModel.AddressInfoForm.AddressLine_1,
                    PostalCode = viewModel.AddressInfoForm.PostalCode,
                    City = viewModel.AddressInfoForm.City,
                };

                await _context.SaveChangesAsync();

                user!.Address = newAddress;
                await _userManager.UpdateAsync(user);
            }
        }
        viewModel.BasicInfoForm ??= await PopulateBasicInfoFormAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoFormAsync();
        viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();

        return View("Details", viewModel);
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
        var user = await _userManager.GetUserAsync(User);
        var address = _context.AspNetAddress.Find(user!.AddressId);
        
            return new AddressInfoFormViewModel
            {
                AddressLine_1 = address.StreetName,
                PostalCode = address.PostalCode,
                City = address.City,
            };        
    }

    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        return new ProfileInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!
        };
    }
}
