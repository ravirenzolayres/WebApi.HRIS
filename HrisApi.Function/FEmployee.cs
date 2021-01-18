using HrisApi.Data.Interface; 
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FEmployee : IFEmployee 
    {
        private readonly IDEmployee _iDEmployee;
        public FEmployee(IDEmployee iDEmployee)
        {
            _iDEmployee = iDEmployee;
        }

        public async Task<Employee> Add(string loggedUser, Employee employee)
        {
            employee.CreatedBy = loggedUser;
            employee.CreatedOn = DateTime.Now;

            await _iDEmployee.Add(employee);
            await _iDEmployee.Complete();
            return await Task.FromResult(employee);
        }

        public async Task<Employee> Edit(string loggedUser,Employee employee)
        {
            employee.UpdatedBy = loggedUser;
            employee.UpdatedOn = DateTime.Now;

            await _iDEmployee.Edit(employee);
            await _iDEmployee.Complete();
            return await Task.FromResult(employee);
        }

        public async Task<Employee> Delete(string loggedUser, Employee employee)
        {
            employee.IsActive = false;
            employee.DeletedBy = loggedUser;
            employee.DeletedOn = DateTime.Now;

            await _iDEmployee.Delete(employee);
            await _iDEmployee.Complete();
            return await Task.FromResult(employee);
        }

        public async Task<Employee> Get(int id)
        {
            return await _iDEmployee.Get(x=>x.IsActive == true && x.IDNo == id);
        }
        public async Task<Employee> Get(Func<Employee, bool> condition)
        {
            return await _iDEmployee.Get(condition);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _iDEmployee.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Employee>> GetAll(Func<Employee,bool> condition)
        {
            return await _iDEmployee.GetAll(condition);
        }

        public async Task<int> GetCode(string employeeCode)
        {
            var systemId = _iDEmployee.Get(x => x.IsActive == true && x.EmployeeCode == employeeCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
