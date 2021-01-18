using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFEmployeeType
    {
        Task<EmployeeType> Add(string loggedUser, EmployeeType employeeType);
        Task<EmployeeType> Edit(string loggedUser,EmployeeType employeeType);
        Task<EmployeeType> Delete(string loggedUser,EmployeeType employeeType);
        Task<EmployeeType> Get(int id);
        Task<EmployeeType> Get(Func<EmployeeType, bool> condition);
        Task<List<EmployeeType>> GetAll();
        Task<List<EmployeeType>> GetAll(Func<EmployeeType, bool> condition);
        Task<int> GetCode(string employeeTypeCode);

    }
}
