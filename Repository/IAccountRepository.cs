﻿using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreWebApp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel cpm);

    }
}