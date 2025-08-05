using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }  // Navigation property
    }
}