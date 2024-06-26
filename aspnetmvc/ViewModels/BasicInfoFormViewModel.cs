﻿using System.ComponentModel.DataAnnotations;

namespace aspnetmvc.ViewModels;

public class BasicInfoFormViewModel
{
    [Required(ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "A valid Email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;


    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone number", Prompt = "Enter your phone number")]
    public string? PhoneNumber { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Bio", Prompt = "Write a short bio...")]
    public string? Biography { get; set; }
}
