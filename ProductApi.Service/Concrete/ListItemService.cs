using AutoMapper;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Uow;
using ProductApi.Dto.Dtos;
using ProductApi.Service.Abstract;


namespace ProductApi.Service.Concrete
{
    public class ListItemService : BaseService<ListItemDto, ListItem>, IListItemService
    {
        private readonly IGenericRepository<ListItem> genericRepository;
        public ListItemService(IGenericRepository<ListItem> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }
    }
}