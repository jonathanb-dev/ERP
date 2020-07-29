using BLL.Exceptions;
using DL.Entities;
using DL.Services;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (appUser == null)
                throw new RestException(HttpStatusCode.NotFound, new { user = "Not found" });

            return appUser;
        }
    }
}