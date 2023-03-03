using AutoMapper;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Uow;
using ProductApi.Dto.Dtos;
using ProductApi.Service.Abstract;


namespace ProductApi.Service.Concrete
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {
        private readonly IGenericRepository<Category> genericRepository;
        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }
    }
}