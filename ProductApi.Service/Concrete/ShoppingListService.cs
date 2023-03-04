using AutoMapper;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Uow;
using ProductApi.Dto.Dtos;
using ProductApi.Service.Abstract;
using System.Collections.Generic;

namespace ProductApi.Service.Concrete
{
    public class ShoppingListService : BaseService<ShoppingListDto, ShoppingList>, IShoppingListService
    {
        private readonly IGenericRepository<ShoppingList> genericRepository;
        public ShoppingListService(IGenericRepository<ShoppingList> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }
    }
}