using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Business.ViewModels
{
    public class GetUserVM
    {
        public AppUser User { get; set; }
        public IList<string> UserRole { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
    }
}
