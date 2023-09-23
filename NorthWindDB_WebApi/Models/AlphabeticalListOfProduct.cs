using System.ComponentModel.DataAnnotations;

namespace NorthWindDB_WebApi.Models
{
    public class AlphabeticalListOfProduct
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }

        public string QuantityPerUnit { get; set; }

        public short? ReorderLevel { get; set; }

        public int? SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }
    }
}
