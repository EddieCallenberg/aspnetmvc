using System.ComponentModel.DataAnnotations;

namespace aspnetmvc.Models;

public class SignUpModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name required.")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name required.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must enter an email address")]
    [RegularExpression("^.+@.+\\..{2,}$", ErrorMessage = "Invalid Email address")]
    public string EmailAddress { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Invalid password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{8,}$",
        ErrorMessage = "Lösenordet måste innehålla minst en stor bokstav, minst en siffra, minst ett specialtecken och vara minst 9 tecken långt.")]
    public string Password { get; set; } = null!;

    [Display(Name = " Confirm Password", Prompt = "Confirm your password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must confirm password")]
    [Compare(nameof(Password), ErrorMessage = "Password does not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms & Conditions.", Order =5)]
    [CheckboxAttribute(ErrorMessage= "You must accept the terms and conditions in order to proceed.")]
    public bool TermsAndConditions { get; set; } = false;
}

public class CheckboxAttribute : ValidationAttribute 
{
    public override bool IsValid(object? value) => value is bool b && b;
}