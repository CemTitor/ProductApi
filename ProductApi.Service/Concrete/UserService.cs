using AutoMapper;
using ProductApi.Base;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Uow;
using ProductApi.Dto.Dtos;
using ProductApi.Service.Abstract;

namespace ProductApi.Service.Concrete
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        private readonly IGenericRepository<User> genericRepository;
        public UserService(IGenericRepository<User> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }

        public override async Task<BaseResponse<UserDto>> InsertAsync(UserDto createUserResource)
        {
            if (createUserResource.UserName == "cemo463")
            {
                return new BaseResponse<UserDto>("Username was cemo463");
            }

            return await base.InsertAsync(createUserResource);
        }
    }
}