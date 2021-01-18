using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFEmployee
    {
        Task<Employee> Add(string loggedUser, Employee employee);
        Task<Employee> Edit(string loggedUser,Employee employee);
        Task<Employee> Delete(string loggedUser,Employee employee);
        Task<Employee> Get(int id);
        Task<Employee> Get(Func<Employee, bool> condition);
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetAll(Func<Employee, bool> condition);
        Task<int> GetCode(string employeeCode);

    }
}
