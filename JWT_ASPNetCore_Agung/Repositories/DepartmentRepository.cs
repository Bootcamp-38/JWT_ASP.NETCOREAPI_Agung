using JWT_ASPNetCore_Agung.Context;
using JWT_ASPNetCore_Agung.Models;
using JWT_ASPNetCore_Agung.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_ASPNetCore_Agung.Repositories
{
    public class DepartmentRepository : DepartmentInterface
    {
        MyContext myContext;

        public DepartmentRepository(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public async Task<int> AddDepartment(Department department)
        {
            if (myContext != null)
            {
                await myContext.Departments.AddAsync(department);
                await myContext.SaveChangesAsync();

                return department.Id;
            }

            return 0;
        }

        public async Task<int> DeleteDepartment(int? Id)
        {
            int result = 0;

            if (myContext != null)
            {
                
                var dept = await myContext.Departments.FirstOrDefaultAsync(x => x.Id == Id);

                if (dept != null)
                {
                    
                    myContext.Departments.Remove(dept);

                    result = await myContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Department>> GetDepartments()
        {
            if (myContext != null)
            {
                return await myContext.Departments.ToListAsync();
            }

            return null;
        }

        public async Task<Department> GetDepartmentsByID(int? Id)
        {
            if (myContext != null)
            {
                return await(from d in myContext.Departments
                             where d.Id == Id
                             select new Department
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task UpdateDepartment(Department department)
        {
            if (myContext != null)
            {
                //Update that post
                myContext.Departments.Update(department);

                //Commit the transaction
                await myContext.SaveChangesAsync();
            }
        }
    }
}