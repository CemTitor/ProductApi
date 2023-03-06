using System.ComponentModel;

namespace ProductApi.Base
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.NormalUser)]
        NormalUser = 2
    }

    public class Role
    {
        public const string Admin = "admin";
        public const string NormalUser = "user";
    }
}