using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFDepartment
    {
        Task<Department> Add(string loggedUser, Department department);
        Task<Department> Edit(string loggedUser,Department department);
        Task<Department> Delete(string loggedUser,Department department);
        Task<Department> Get(int id);
        Task<Department> Get(Func<Department, bool> condition);
        Task<List<Department>> GetAll();
        Task<List<Department>> GetAll(Func<Department, bool> condition);
        Task<int> GetCode(string departmentCode);
    }
}
