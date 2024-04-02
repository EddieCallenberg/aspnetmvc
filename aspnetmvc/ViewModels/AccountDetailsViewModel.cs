using Infrastructure.Entities;

namespace aspnetmvc.ViewModels;

public class AccountDetailsViewModel
{
    public UserEntity User { get; set; } = null!;
    public string Title { get; set; } = "Account Details";
    public BasicInfoFormViewModel BasicInfoForm { get; set; } = null!;
    //public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();

}
