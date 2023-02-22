﻿using System.Linq;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel userInputModel)
        {
            var user = new User(userInputModel.Fullname, userInputModel.Email, userInputModel.BirthDate);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            
            if(user is null) return null;
            

            return new UserViewModel(user.Fullname, user.Email);
        }
    }
}
