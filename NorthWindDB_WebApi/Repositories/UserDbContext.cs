using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Entities;
using NorthWindDB_WebApi.Repositories.Contracts;

namespace NorthWindDB_WebApi.Repositories
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public DbSet<Users> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}
