using ProductApi.Base;
using ProductApi.Base;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class UpdatePasswordRequest
    {
        [Required]
        [PasswordAttribute]
        public string OldPassword { get; set; }

        [Required]
        [Password]
        public string NewPassword { get; set; }
    }
}