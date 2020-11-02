using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_ASPNetCore_Agung.Models;
using JWT_ASPNetCore_Agung.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_ASPNetCore_Agung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        DepartmentInterface departmentInterface;
        public DepartmentsController(DepartmentInterface _departmentInterface)
        {
            departmentInterface = _departmentInterface;
        }
        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await departmentInterface.GetDepartments();
                if (departments == null)
                {
                    return NotFound();
                }
                return Ok(departments);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetDepartmentsByID")]
        public async Task<IActionResult> GetDepartmentsByID(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var dept = await departmentInterface.GetDepartmentsByID(id);

                if (dept == null)
                {
                    return NotFound();
                }

                return Ok(dept);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteDepartments")]
        public async Task<IActionResult> DeleteDepartments(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await departmentInterface.DeleteDepartment(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("Data has been deleted.");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddDepartments")]
        public async Task<IActionResult> AddDepartments([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var deptId = await departmentInterface.AddDepartment(department);
                    if (deptId > 0)
                    {
                        return Ok(deptId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("UpdateDepartments")]
        public async Task<IActionResult> UpdateDepartments([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await departmentInterface.UpdateDepartment(department);

                    return Ok("Data has been changed");
                }
                catch (Exception ex)
                {
                    if (ex.GetType().Name ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
