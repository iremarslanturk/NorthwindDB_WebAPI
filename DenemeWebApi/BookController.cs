using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenemeWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Book>()
            {
                new Book() { Name = "kjdf", Number = "Computer"},
                new Book() { Name = "djfhdfk", Number = "Computer"},
            
            };
            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Book book)
        {

            _logger.LogWarning("Book has been created");
            return StatusCode(201);
        }
    }
}
