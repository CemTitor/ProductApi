using ProductApi.Base;
using System.ComponentModel.DataAnnotations;


namespace ProductApi.Dto.Dtos
{
    public class ProductDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(125)]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required]
        [MaxLength(125)]
        [ProductPriceAttribute]
        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Product Quantity")]
        public int ProductQuantity { get; set; }

        [Required]
        [MaxLength(125)]
        [ProductCategoryAttribute]
        [Display(Name = "Product Category")]
        public string ProductCategory { get; set; }
     

     
    }
}