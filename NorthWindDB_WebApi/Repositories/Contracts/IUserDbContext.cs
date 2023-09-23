using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Entities;

namespace NorthWindDB_WebApi.Repositories.Contracts
{
    public interface IUserDbContext
    {
        DbSet<Users> Users { get; set; }
        int SaveChanges();
    }

}
