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
    public class RegionController : ControllerBase
    {

        private readonly RegionDbContext _regionContext;
        public RegionController(RegionDbContext context)
        {
            _regionContext = context;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            try
            { 
            
                var regions = _regionContext.Region.ToList();
                return Ok(regions);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionById(int id)
        {
            try
            {
                var regions = _regionContext.Region.FirstOrDefault(c => c.RegionId.Equals(id));

                if (regions == null)
                {
                    return NotFound($"Region with ID {id} not found.");
                }

                return Ok(regions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegion(int id)
        {
            try
            {
                var region = _regionContext.Region.FirstOrDefault(c => c.RegionId == id);

                if (region == null)
                {
                    return NotFound($"Region with ID {id} not found.");
                }

                _regionContext.Region.Remove(region);
                // _regionContext.SaveChanges();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] Region region)
        {
            try
            {
                if (region == null)
                {
                    return BadRequest("Region data is null.");
                }

                var existingRegion = _regionContext.Region.FirstOrDefault(r => r.RegionId == region.RegionId);

                if (existingRegion != null)
                {
                    return Conflict($"Region with ID {region.RegionId} already exists.");
                }

                _regionContext.Region.Add(region);
               // _regionContext.SaveChanges();

                return CreatedAtAction(nameof(GetRegionById), new { id = region.RegionId }, region);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateRegion(int id, [FromBody] Region updatedRegion)
        {
            try
            {
                var existingRegion = _regionContext.Region.FirstOrDefault(r => r.RegionId == id);

                if (existingRegion == null)
                {
                    return NotFound($"Region with ID {id} not found.");
                }

                existingRegion.RegionDescription = updatedRegion.RegionDescription;
                //  _regionContext.SaveChanges(); 

                return Ok(existingRegion);
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
        public IActionResult PartialUpdateRegion(int id, [FromBody] JsonPatchDocument<Region> patchDocument)
        {
            try
            {
                var existingRegion = _regionContext.Region.FirstOrDefault(r => r.RegionId == id);

                if (existingRegion == null)
                {
                    return NotFound($"Region with ID {id} not found.");
                }

                var regionToPatch = new Region
                {
                    RegionId = existingRegion.RegionId,
                    RegionDescription = existingRegion.RegionDescription
                };

                patchDocument.ApplyTo(regionToPatch, ModelState);

                if (!TryValidateModel(regionToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingRegion.RegionDescription = regionToPatch.RegionDescription;
                // _regionContext.SaveChanges();

                return Ok(existingRegion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}

