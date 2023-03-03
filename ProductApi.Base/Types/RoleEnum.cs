using System.ComponentModel;

namespace ProductApi.Base
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.Viewer)]
        Viewer = 2
    }

    public class Role
    {
        public const string Admin = "admin";
        public const string Viewer = "viewer";
    }
}