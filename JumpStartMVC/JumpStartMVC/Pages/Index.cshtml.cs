using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JumpStartMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JumpStartMVC.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginInfo { get; set; }
        public void OnGet()
        {
        }
    }
}
