using System.ComponentModel.DataAnnotations;

namespace aspnetmvc.Models;

public class AccountDetailsAddressInfoModel
{
    [Display(Name = "Address line 1", Prompt = "Enter your address line 1", Order = 0)]
    [Required(ErrorMessage = "Address line is required.")]
    public string AdressLine_1 { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your address line 2", Order = 1)]
    public string? AdressLine_2 { get; set; }

    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
    [Required(ErrorMessage = "Postal code is required.")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; } = null!;
}
