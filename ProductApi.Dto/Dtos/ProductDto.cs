using ProductApi.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Dto.Dtos
{
    public class ProductDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(125)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(125)]
        [PriceAttribute]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [MaxLength(125)]
        //[CategoryAttribute]
        [Display(Name = "Product Category")]
        public string Category { get; set; }

    }
}