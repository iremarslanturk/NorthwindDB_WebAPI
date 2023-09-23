using JWTWebAuthentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWindDB_WebApi.Entities;
using NorthWindDB_WebApi.Models;
using NorthWindDB_WebApi.Repositories;
using System.Net.Http;

namespace NorthWindDB_WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryDbContext _categoryContext;
        private readonly HttpClient _testApiClient;

        public CategoryController(CategoryDbContext context, IHttpClientFactory httpClientFactory)
        {
            _categoryContext = context;
            _testApiClient = httpClientFactory.CreateClient("TestApiClient");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryContext.Categories.ToListAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = _categoryContext.Categories.FirstOrDefault(c => c.CategoryId == id);

                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                _categoryContext.Categories.Remove(category);
                //_categoryContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Category data is null.");
                }

                var existingCategory = _categoryContext.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);

                if (existingCategory != null)
                {
                    return Conflict($"Category with ID {category.CategoryId} already exists.");
                }

                _categoryContext.Categories.Add(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async  Task<IActionResult> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            try
            {
                var existingCategory = _categoryContext.Categories.FirstOrDefault(c => c.CategoryId == id);

                if (existingCategory == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                existingCategory.CategoryName = updatedCategory.CategoryName;
                existingCategory.Description = updatedCategory.Description;
                existingCategory.Picture = updatedCategory.Picture;

                //  _categoryContext.SaveChanges(); 
                return Ok(existingCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateCategory(int id, [FromBody] JsonPatchDocument<Category> patchDocument)
        {
            try
            {
                var existingCategory = _categoryContext.Categories.FirstOrDefault(c => c.CategoryId == id);

                if (existingCategory == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                var categoryToPatch = new Category
                {
                    CategoryId = existingCategory.CategoryId,
                    CategoryName = existingCategory.CategoryName,
                    Description = existingCategory.Description,
                    Picture = existingCategory.Picture
                };

                patchDocument.ApplyTo(categoryToPatch, ModelState);

                if (!TryValidateModel(categoryToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingCategory.CategoryName = categoryToPatch.CategoryName;
                existingCategory.Description = categoryToPatch.Description;
                existingCategory.Picture = categoryToPatch.Picture;

                // _categoryContext.SaveChanges(); 
                return Ok(existingCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("external")]
        public async Task<IActionResult> GetExternalData()
        {
            try
            {
                HttpResponseMessage response = await _testApiClient.GetAsync("/posts/1");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return Ok(data);
                }

                return StatusCode((int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
    

