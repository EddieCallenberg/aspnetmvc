namespace aspnetmvc.ViewModels;

public class ProfileInfoViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PofileImageUrl { get; set; } = "~/images/profile-picture-image.svg";
}