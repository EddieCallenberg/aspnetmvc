using aspnetmvc.Models;
using Infrastructure.Entities;

namespace aspnetmvc.ViewModels;

public class AccountDetailsViewModel
{
    public UserEntity User { get; set; } = null!;
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "/images/profile-picture-image.svg"
    };
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();

}
