using Microsoft.AspNetCore.Identity;

namespace DL.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string DisplayName { get; set; }
    }
}