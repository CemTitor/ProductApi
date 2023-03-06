using AutoMapper;
using ProductApi.Data.Model;
using ProductApi.Dto.Dtos;

namespace ProductApi.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<ShoppingList, ShoppingListDto>();
            CreateMap<ShoppingListDto, ShoppingList>();

            CreateMap<ListItem, ListItemDto>();
            CreateMap<ListItemDto, ListItem>();
        }
    }
}