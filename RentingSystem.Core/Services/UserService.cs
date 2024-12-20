﻿using Microsoft.EntityFrameworkCore;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Admin;
using RentingSystem.Infrastructure.Data.Common;
using RentingSystem.Infrastructure.Data.Models;

namespace RentingSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Dealer)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Dealer != null ? u.Dealer.PhoneNumber : null,
                    IsDealer = u.Dealer != null
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
