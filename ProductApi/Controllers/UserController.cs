using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Base;
using ProductApi.Dto.Dtos;
using ProductApi.Service.Abstract;
using Serilog;

namespace ProductApi.Controllers
{
    [Route("param/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<BaseResponse<IEnumerable<UserDto>>> Get()
        {
            Log.Debug("UserContoller.Get");
            var users = await service.GetAllAsync();
            return users;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<BaseResponse<UserDto>> GetById(int id)
        {
            Log.Debug("UserContoller.GetById");
            var user = await service.GetByIdAsync(id);
            return user;
        }

        [HttpPost]
        [Authorize]
        public async Task<BaseResponse<UserDto>> Post([FromBody] UserDto dto)
        {
            Log.Debug("UserContoller.Post");

            dto.CreatedAt = DateTime.Now;
            dto.CreatedBy = "SystemUser";

            var user = await service.InsertAsync(dto);
            return user;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<BaseResponse<UserDto>> Put(int id, [FromBody] UserDto dto)
        {
            Log.Debug("UserContoller.Put");
            var user = await service.UpdateAsync(id, dto);
            return user;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<BaseResponse<UserDto>> Delete(int id)
        {
            Log.Debug("UserContoller.Delete");
            var user = await service.RemoveAsync(id);
            return user;
        }


    }
}