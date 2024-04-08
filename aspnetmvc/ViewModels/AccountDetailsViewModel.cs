using Infrastructure.Entities;

namespace aspnetmvc.ViewModels;

public class AccountDetailsViewModel
{
    public UserEntity? User { get; set; }
    public string Title { get; set; } = "Account Details";
    public BasicInfoFormViewModel? BasicInfoForm { get; set; } = null!;
    public AddressInfoFormViewModel? AddressInfoForm { get; set; } = null!;
}
