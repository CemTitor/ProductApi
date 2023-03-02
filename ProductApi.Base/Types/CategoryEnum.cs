using System.ComponentModel;

namespace ProductApi.Base
{
    public enum CategoryEnum
    {
        [Description(Category.Food)]
        Food = 1,

        [Description(Category.Drink)]
        Drink = 2,

        [Description(Category.Clothes)]
        Clothes = 3,

        [Description(Category.Electronic)]
        Electronic = 4

    }

    public class Category
    {
        public const string Food = "food";
        public const string Drink = "drink";
        public const string Clothes = "clothes";
        public const string Electronic = "electronic";
    }
}