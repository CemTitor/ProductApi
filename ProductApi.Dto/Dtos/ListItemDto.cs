using ProductApi.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Dto.Dtos
{
    public class ListItemDto : BaseDto
    {
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public ShoppingListDto ShoppingList { get; set; }
        public ProductDto Product { get; set; }

    }
}