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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeContext;
        public EmployeeController(EmployeeDbContext context)
        {
            _employeeContext = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeContext.Employees.ToList();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeContext.Employees.FirstOrDefault(c => c.EmployeeId.Equals(id));

                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeContext.Employees.FirstOrDefault(c => c.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                _employeeContext.Employees.Remove(employee);
                // _categoryContext.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee data is null.");
                }

                var existingEmployee = _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

                if (existingEmployee != null)
                {
                    return Conflict($"Employee with ID {employee.EmployeeId} already exists.");
                }

                _employeeContext.Employees.Add(employee);
              //  _employeeContext.SaveChanges();

                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            try
            {
                var existingEmployee = _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (existingEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                existingEmployee.LastName = updatedEmployee.LastName;
                existingEmployee.FirstName = updatedEmployee.FirstName;
                existingEmployee.Title = updatedEmployee.Title;
                existingEmployee.TitleOfCourtesy = updatedEmployee.TitleOfCourtesy;
                existingEmployee.BirthDate = updatedEmployee.BirthDate;
                existingEmployee.HireDate = updatedEmployee.HireDate;
                existingEmployee.Address = updatedEmployee.Address;
                existingEmployee.City = updatedEmployee.City;
                existingEmployee.Region = updatedEmployee.Region;
                existingEmployee.PostalCode = updatedEmployee.PostalCode;
                existingEmployee.Country = updatedEmployee.Country;
                existingEmployee.HomePhone = updatedEmployee.HomePhone;
                existingEmployee.Extension = updatedEmployee.Extension;
                existingEmployee.Photo = updatedEmployee.Photo;
                existingEmployee.Notes = updatedEmployee.Notes;
                existingEmployee.ReportsTo = updatedEmployee.ReportsTo;
                existingEmployee.PhotoPath = updatedEmployee.PhotoPath;

               // _employeeContext.SaveChanges(); 

                return Ok(existingEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPatch("{id}")]
        public IActionResult PartialUpdateEmployee(int id, [FromBody] JsonPatchDocument<Employee> patchDocument)
        {
            try
            {
                var existingEmployee = _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (existingEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                var employeeToPatch = new Employee
                {
                    EmployeeId = existingEmployee.EmployeeId,
                    LastName = existingEmployee.LastName,
                    FirstName = existingEmployee.FirstName,
                    Title = existingEmployee.Title,
                    TitleOfCourtesy = existingEmployee.TitleOfCourtesy,
                    BirthDate = existingEmployee.BirthDate,
                    HireDate = existingEmployee.HireDate,
                    Address = existingEmployee.Address,
                    City = existingEmployee.City,
                    Region = existingEmployee.Region,
                    PostalCode = existingEmployee.PostalCode,
                    Country = existingEmployee.Country,
                    HomePhone = existingEmployee.HomePhone,
                    Extension = existingEmployee.Extension,
                    Photo = existingEmployee.Photo,
                    Notes = existingEmployee.Notes,
                    ReportsTo = existingEmployee.ReportsTo,
                    PhotoPath = existingEmployee.PhotoPath
                };

                patchDocument.ApplyTo(employeeToPatch, ModelState);

                if (!TryValidateModel(employeeToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingEmployee.LastName = employeeToPatch.LastName;
                existingEmployee.FirstName = employeeToPatch.FirstName;
                existingEmployee.Title = employeeToPatch.Title;
                existingEmployee.TitleOfCourtesy = employeeToPatch.TitleOfCourtesy;
                existingEmployee.BirthDate = employeeToPatch.BirthDate;
                existingEmployee.HireDate = employeeToPatch.HireDate;
                existingEmployee.Address = employeeToPatch.Address;
                existingEmployee.City = employeeToPatch.City;
                existingEmployee.Region = employeeToPatch.Region;
                existingEmployee.PostalCode = employeeToPatch.PostalCode;
                existingEmployee.Country = employeeToPatch.Country;
                existingEmployee.HomePhone = employeeToPatch.HomePhone;
                existingEmployee.Extension = employeeToPatch.Extension;
                existingEmployee.Photo = employeeToPatch.Photo;
                existingEmployee.Notes = employeeToPatch.Notes;
                existingEmployee.ReportsTo = employeeToPatch.ReportsTo;
                existingEmployee.PhotoPath = employeeToPatch.PhotoPath;

                // _employeeContext.SaveChanges();

                return Ok(existingEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
