using ProductApi.Base;

namespace ProductApi.Data.Model
{
    public class ShoppingList : BaseModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Note { get; set; }
        //public virtual List<ListItem> ListItems { get; set; }

    }
}