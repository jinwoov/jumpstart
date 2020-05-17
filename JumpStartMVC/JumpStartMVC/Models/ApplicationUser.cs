using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JumpStartMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Job JobType { get; set; }
    }

    public enum Job
    {
        FullTime = 0,
        PartTime = 1,
        Temp = 2,
        Gig = 3
    }
}
