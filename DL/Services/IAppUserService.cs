﻿using DL.Entities;
using System.Threading.Tasks;

namespace DL.Services
{
    public interface IAppUserService
    {
        Task<AppUser> GetUserByEmailAsync(string email);
    }
}