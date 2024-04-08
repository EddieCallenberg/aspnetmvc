using System.ComponentModel.DataAnnotations;

namespace aspnetmvc.ViewModels;

public class AddressInfoFormViewModel
{
    [Required(ErrorMessage = "A valid Address is required")]
    [DataType(DataType.Text)]
    [Display(Name = "Address line 1", Prompt = "Enter your Address line 1")]
    public string AddressLine_1 { get; set; } = null!;



    [DataType(DataType.Text)]
    [Display(Name = "Address line 2  (optional)", Prompt = "Enter your Address line 2")]
    public string? AddressLine_2 { get; set; }



    [Required(ErrorMessage = "A valid Postal code is required")]
    [DataType(DataType.PostalCode)]
    [Display(Name = "Address line 1", Prompt = "Enter your Postal code")]
    public string PostalCode { get; set; } = null!;



    [Required(ErrorMessage = "A valid City is required")]
    [DataType(DataType.Text)]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
}
