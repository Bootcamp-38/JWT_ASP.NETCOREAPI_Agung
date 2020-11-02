using JWT_ASPNetCore_Agung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_ASPNetCore_Agung.Repositories.Interface
{
    public interface DepartmentInterface
    {
        Task<List<Department>> GetDepartments();

        Task<Department> GetDepartmentsByID(int? Id);

        Task<int> AddDepartment(Department department);

        Task UpdateDepartment(Department department);

        Task<int> DeleteDepartment(int? Id);
    }
}
