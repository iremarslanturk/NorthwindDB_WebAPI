using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NorthWindDB_WebApi.Models;
using NorthWindDB_WebApi.Repositories;

namespace NorthWindDB_WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoryController : ControllerBase
    {
        private readonly TerritoryDbContext _territoryContext;
        public TerritoryController(TerritoryDbContext context)
        {
            _territoryContext = context;
        }

        [HttpGet]
        public IActionResult GetAllTerritories()
        {
            try
            {
                var territories = _territoryContext.Territories.ToList();
                return Ok(territories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTerritoryById(string id)
        {
            try
            {
                var territory = _territoryContext.Territories.FirstOrDefault(c => c.TerritoryId.Equals(id));

                if (territory == null)
                {
                    return NotFound($"Territory with ID {id} not found.");
                }

                return Ok(territory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTerritory(string id)
        {
            try
            {
                var territory = _territoryContext.Territories.FirstOrDefault(c => c.TerritoryId.Equals(id));

                if (territory == null)
                {
                    return NotFound($"Territory with ID {id} not found.");
                }

                _territoryContext.Territories.Remove(territory);
                // _shipperContext.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateTerritory([FromBody] Territory territory)
        {
            try
            {
                if (territory == null)
                {
                    return BadRequest("Territory data is null.");
                }

                var existingTerritory = _territoryContext.Territories.FirstOrDefault(t => t.TerritoryId == territory.TerritoryId);

                if (existingTerritory != null)
                {
                    return Conflict($"Territory with ID {territory.TerritoryId} already exists.");
                }

                _territoryContext.Territories.Add(territory);
               // _territoryContext.SaveChanges();

                return CreatedAtAction(nameof(GetTerritoryById), new { id = territory.TerritoryId }, territory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTerritory(string id, [FromBody] Territory updatedTerritory)
        {
            try
            {
                var existingTerritory = _territoryContext.Territories.FirstOrDefault(t => t.TerritoryId == id);

                if (existingTerritory == null)
                {
                    return NotFound($"Territory with ID {id} not found.");
                }

                existingTerritory.TerritoryDescription = updatedTerritory.TerritoryDescription;
                existingTerritory.RegionId = updatedTerritory.RegionId;

                //_territoryContext.SaveChanges();

                return Ok(existingTerritory);
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
        public IActionResult PartialUpdateTerritory(string id, [FromBody] JsonPatchDocument<Territory> patchDocument)
        {
            try
            {
                var existingTerritory = _territoryContext.Territories.FirstOrDefault(t => t.TerritoryId == id);

                if (existingTerritory == null)
                {
                    return NotFound($"Territory with ID {id} not found.");
                }

                var territoryToPatch = new Territory
                {
                    TerritoryId = existingTerritory.TerritoryId,
                    TerritoryDescription = existingTerritory.TerritoryDescription,
                    RegionId = existingTerritory.RegionId
                };

                patchDocument.ApplyTo(territoryToPatch, ModelState);

                if (!TryValidateModel(territoryToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingTerritory.TerritoryDescription = territoryToPatch.TerritoryDescription;
                existingTerritory.RegionId = territoryToPatch.RegionId;

                // _territoryContext.SaveChanges(); 

                return Ok(existingTerritory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}

