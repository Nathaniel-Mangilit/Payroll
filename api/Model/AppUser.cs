using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Model
{
    public class AppUser : IdentityUser
    {
        
        public List<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}