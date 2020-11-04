using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_ASPNetCore_Agung.Bases;
using JWT_ASPNetCore_Agung.Context;
using JWT_ASPNetCore_Agung.Models;
using JWT_ASPNetCore_Agung.Repositories.Data;
using JWT_ASPNetCore_Agung.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_ASPNetCore_Agung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController<Department, DepartmentRepository>    
    {
        public DepartmentsController (DepartmentRepository department):base(department)
        {

        }

    }
}
