using ProductApi.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data.Model
{
    public class ListItem : BaseModel
    {
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public Product Product { get; set; }
    }
}