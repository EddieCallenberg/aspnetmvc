using aspnetmvc.Models;

namespace aspnetmvc.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "/images/profile-picture-image.svg",
        FirstName = "Eddie",
        LastName = "Callenberg",
        EmailAddress = "eddie@domain.com"

    };
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();

}
