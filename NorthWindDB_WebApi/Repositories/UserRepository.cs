using NorthWindDB_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NorthWindDB_WebApi.Repositories.Contracts;

namespace NorthWindDB_WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsUsernameTaken(string username)
        {
            return _dbContext.Users.Any(u => u.Name == username);
        }

        public void RegisterUser(Users userData)
        {
            _dbContext.Users.Add(userData);
            _dbContext.SaveChanges();
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == username);

            if (user != null)
            {
                return user.Password == password;
            }

            return false;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
