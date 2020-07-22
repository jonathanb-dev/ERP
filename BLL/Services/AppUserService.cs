﻿using BLL.Exceptions;
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

        public async Task<AppUser> GetUserByNameAsync(string name)
        {
            AppUser appUser = await _userManager.FindByNameAsync(name);

            if (appUser == null)
                throw new RestException(HttpStatusCode.NotFound, new { user = "Not found" });

            return appUser;
        }
    }
}