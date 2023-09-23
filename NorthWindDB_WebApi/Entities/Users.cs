using System.ComponentModel.DataAnnotations;

namespace NorthWindDB_WebApi.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
