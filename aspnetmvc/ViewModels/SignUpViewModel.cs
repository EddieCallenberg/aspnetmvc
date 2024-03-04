using aspnetmvc.Models;

namespace aspnetmvc.ViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public SignUpModel SignUpForm { get; set; } = new SignUpModel();

    public bool TermsAndConditions { get; set; } = false;
}
