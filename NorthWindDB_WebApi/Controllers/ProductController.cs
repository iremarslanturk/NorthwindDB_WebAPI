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
    public class ProductController : ControllerBase
    {

        private readonly ProductDbContext _productContext;
        public ProductController(ProductDbContext context)
        {
            _productContext = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productContext.Products.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var products = _productContext.Products.FirstOrDefault(c => c.ProductId.Equals(id));

                if (products == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _productContext.Products.FirstOrDefault(c => c.ProductId == id);

                if (product == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                _productContext.Products.Remove(product);
                // _productContext.SaveChanges();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product data is null.");
                }

                var existingProduct = _productContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                if (existingProduct != null)
                {
                    return Conflict($"Product with ID {product.ProductId} already exists.");
                }

                _productContext.Products.Add(product);
                //_productContext.SaveChanges();

                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                var existingProduct = _productContext.Products.FirstOrDefault(p => p.ProductId == id);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.SupplierId = updatedProduct.SupplierId;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                existingProduct.QuantityPerUnit = updatedProduct.QuantityPerUnit;
                existingProduct.UnitPrice = updatedProduct.UnitPrice;
                existingProduct.UnitsInStock = updatedProduct.UnitsInStock;
                existingProduct.UnitsOnOrder = updatedProduct.UnitsOnOrder;
                existingProduct.ReorderLevel = updatedProduct.ReorderLevel;
                existingProduct.Discontinued = updatedProduct.Discontinued;

                //  _productContext.SaveChanges();

                return Ok(existingProduct);
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
        public IActionResult PartialUpdateProduct(int id, [FromBody] JsonPatchDocument<Product> patchDocument)
        {
            try
            {
                var existingProduct = _productContext.Products.FirstOrDefault(p => p.ProductId == id);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                var productToPatch = new Product
                {
                    ProductId = existingProduct.ProductId,
                    ProductName = existingProduct.ProductName,
                    SupplierId = existingProduct.SupplierId,
                    CategoryId = existingProduct.CategoryId,
                    QuantityPerUnit = existingProduct.QuantityPerUnit,
                    UnitPrice = existingProduct.UnitPrice,
                    UnitsInStock = existingProduct.UnitsInStock,
                    UnitsOnOrder = existingProduct.UnitsOnOrder,
                    ReorderLevel = existingProduct.ReorderLevel,
                    Discontinued = existingProduct.Discontinued
                };

                patchDocument.ApplyTo(productToPatch, ModelState);

                if (!TryValidateModel(productToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                existingProduct.ProductName = productToPatch.ProductName;
                existingProduct.SupplierId = productToPatch.SupplierId;
                existingProduct.CategoryId = productToPatch.CategoryId;
                existingProduct.QuantityPerUnit = productToPatch.QuantityPerUnit;
                existingProduct.UnitPrice = productToPatch.UnitPrice;
                existingProduct.UnitsInStock = productToPatch.UnitsInStock;
                existingProduct.UnitsOnOrder = productToPatch.UnitsOnOrder;
                existingProduct.ReorderLevel = productToPatch.ReorderLevel;
                existingProduct.Discontinued = productToPatch.Discontinued;

                // _productContext.SaveChanges(); 

                return Ok(existingProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}

