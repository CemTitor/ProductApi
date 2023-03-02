using ProductApi.Base;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto.Dtos
{
    public class UserDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [PasswordAttribute]
        public string Password { get; set; }

        [Required]
        [EmailAddressAttribute]
        [MaxLength(500)]
        public string Email { get; set; }

        [Required]
        [RoleAttribute]
        public int Role { get; set; }   
       
    }
}