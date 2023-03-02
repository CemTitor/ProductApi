using ProductApi.Base;

namespace ProductApi.Data.Model
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductCategory { get; set; }
      
    }
}