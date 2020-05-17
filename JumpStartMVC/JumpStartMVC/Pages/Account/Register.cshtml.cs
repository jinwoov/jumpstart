using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JumpStartMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JumpStartMVC.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public RegisterInfo RegisterData { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task OnPost() 
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = RegisterData.Email,
                    Email = RegisterData.Email,
                    FirstName = RegisterData.FirstName,
                    LastName = RegisterData.LastName,
                    JobType = Enum.Parse<Job>(RegisterData.JobType)
                };

                var result = await _userManager.CreateAsync(user, RegisterData.Password);

                if(result.Succeeded)
                {
                    Claim name = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim jobType = new Claim("JobType", user.JobType.ToString());

                    List<Claim> claims = new List<Claim>()
                    {
                        name, jobType
                    };

                    await _userManager.AddClaimsAsync(user, claims);

                    // make a interface to call out to api here
                }
            }
        }

        public class RegisterInfo
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Username / Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Password does not match")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Job Type Preference ?")]
            public string JobType { get; set; } 

        }

    }
}
