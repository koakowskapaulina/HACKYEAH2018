﻿using BE.ApiModels;
using BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Services
{
    public interface IUserService
    {
        User checkUserCredentials(LoginModel model);
    }

    public class UserService : IUserService
    {
        IMockService mockService;

        public UserService(IMockService _mockService)
        {
            mockService = _mockService;
        }
        public User checkUserCredentials(LoginModel model)
        {
            try
            {
                var users = mockService.InitUsers();

                return users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
