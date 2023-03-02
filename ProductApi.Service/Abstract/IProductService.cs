using ProductApi.Data.Model;
using ProductApi.Dto.Dtos;

namespace ProductApi.Service.Abstract
{
    public interface IProductService : IBaseService<ProductDto, Product>
    {

    }
}