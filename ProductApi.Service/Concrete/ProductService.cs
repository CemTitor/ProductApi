using AutoMapper;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Uow;
using ProductApi.Dto.Dtos;
using ProductApi.Service.Abstract;


namespace ProductApi.Service.Concrete
{
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        private readonly IGenericRepository<Product> genericRepository;
        public ProductService(IGenericRepository<Product> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }
    }
}