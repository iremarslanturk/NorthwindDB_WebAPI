using JWTWebAuthentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindDB_WebApi.Entities;
using NorthWindDB_WebApi.Repositories;
using NorthWindDB_WebApi.Repositories.Contracts;
using System.Security.Claims;

namespace NorthWindDB_WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly IUserRepository _userRepository;
        private readonly IUserDbContext _userDbContext; 

        public UsersController(IJWTManagerRepository jWTManager, IUserRepository userRepository, IUserDbContext userDbContext)
        {
            _jWTManager = jWTManager;
            _userRepository = userRepository;
            _userDbContext = userDbContext;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                /*
                var userIdentity = HttpContext.User.Identity as ClaimsIdentity;

                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("Token is invalid or expired.");
                }
                */

                var users = _userDbContext.Users.ToList(); 
                var usernames = users.Select(user => user.Name).ToList();

                return Ok(usernames);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users userData)
        {
            var token = _jWTManager.Authenticate(userData);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register(Users userData)
        {
            try
            {
                if (_userRepository.IsUsernameTaken(userData.Name))
                {
                    return BadRequest("Username is already taken.");
                }

                _userDbContext.Users.Add(userData); 
                _userDbContext.SaveChanges(); 

                var token = _jWTManager.Authenticate(userData);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
