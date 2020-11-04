using JWT_ASPNetCore_Agung.Context;
using JWT_ASPNetCore_Agung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_ASPNetCore_Agung.Repositories
{
    public class RolesRepository : GeneralRepository<Role, MyContext>
    {
        public RolesRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
