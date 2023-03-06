using ProductApi.Base;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto.Dtos
{
    public class UserDto : BaseDto
    {
        [UserNameAttribute]
        public string UserName { get; set; }

        [PasswordAttribute]
        public string Password { get; set; }

        [EmailAddressAttribute]
        public string Email { get; set; }

        [RoleAttribute]
        public string Role { get; set; }

        public DateTime LastActivity { get; set; }


    }
}