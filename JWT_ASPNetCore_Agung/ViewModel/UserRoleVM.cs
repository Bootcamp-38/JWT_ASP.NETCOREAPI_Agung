using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_ASPNetCore_Agung.ViewModel
{
    public class UserRoleVM
    {
        public int Id { get; set; }
        public int User_UserId { get; set; }
        public string User_Email { get; set; }
        public string User_password { get; set; }
        public int Role_RoleId { get; set; }
        public string Role_Name { get; set; }
    }
}
