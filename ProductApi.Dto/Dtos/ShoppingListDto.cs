using ProductApi.Base;

namespace ProductApi.Dto.Dtos
{
    public class ShoppingListDto : BaseDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public string Note { get; set; }

    }
}