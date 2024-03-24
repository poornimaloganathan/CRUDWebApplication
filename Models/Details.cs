using System.ComponentModel.DataAnnotations;

namespace CRUDWebApplication.Models
{
    public class Details
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }
    }
}
