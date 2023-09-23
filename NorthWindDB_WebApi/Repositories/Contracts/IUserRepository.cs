using NorthWindDB_WebApi.Entities;

namespace NorthWindDB_WebApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllUsers();
        bool IsUsernameTaken(string username);
        void RegisterUser(Users userData);
        bool ValidateUser(string name, string password);
    }
}
