using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceASP.Models
{
    public class MyIdentityUser:IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
