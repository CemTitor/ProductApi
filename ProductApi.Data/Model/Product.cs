using ProductApi.Base;

namespace ProductApi.Data.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}