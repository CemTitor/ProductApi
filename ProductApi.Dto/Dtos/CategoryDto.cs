using ProductApi.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Dto.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
    }
}