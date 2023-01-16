using System.ComponentModel.DataAnnotations;

namespace BlazorNorthwindUI.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string QuantityPerUnit { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Range(0,100)]
        public int UnitsInStock { get; set; }
    }
}
