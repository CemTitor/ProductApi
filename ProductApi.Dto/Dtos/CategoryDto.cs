using ProductApi.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Dto.Dtos
{
    public class CategoryDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}