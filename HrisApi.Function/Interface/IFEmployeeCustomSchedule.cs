using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFEmployeeCustomSchedule
    {
        Task<EmployeeCustomSchedule> Add(string loggedUser, EmployeeCustomSchedule employeeCustomSchedule);
        Task<EmployeeCustomSchedule> Edit(string loggedUser,EmployeeCustomSchedule employeeCustomSchedule);
        Task<EmployeeCustomSchedule> Delete(string loggedUser,EmployeeCustomSchedule employeeCustomSchedule);
        Task<EmployeeCustomSchedule> Get(int id);
        Task<EmployeeCustomSchedule> Get(Func<EmployeeCustomSchedule, bool> condition);
        Task<List<EmployeeCustomSchedule>> GetAll();
        Task<List<EmployeeCustomSchedule>> GetAll(Func<EmployeeCustomSchedule, bool> condition);
    }
}
