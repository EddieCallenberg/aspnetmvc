using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace aspnetmvc.ViewModels;

public class NewsletterViewModel
{
    [Required(ErrorMessage = "A valid Email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Your Email")]
    public string Email { get; set; } = null!;
}
