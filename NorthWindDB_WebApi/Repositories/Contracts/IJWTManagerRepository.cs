using NorthWindDB_WebApi.Entities;
namespace JWTWebAuthentication.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
      
    }
}