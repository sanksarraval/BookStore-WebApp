﻿namespace BookStoreWebApp.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAunthenticated();
    }
}