using ProductApi.Base;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto.Dtos
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }   
       
    }
}