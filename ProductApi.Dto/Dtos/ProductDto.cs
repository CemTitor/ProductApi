using ProductApi.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Dto.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

    }
}