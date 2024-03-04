using aspnetmvc.Models;

namespace aspnetmvc.ViewModels
{
    public class SignInViewModel
    {
        public string Title { get; set; } = "Sign in";

        public SignInModel Form { get; set; } = new SignInModel();

        public string ErrorMessage { get; set; } = null!;
    }
}
