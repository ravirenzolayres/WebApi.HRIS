using HrisApi.Data.Interface; 
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FEmployeeCustomSchedule : IFEmployeeCustomSchedule 
    {
        private readonly IDEmployeeCustomSchedule _iDEmployeeCustomSchedule;

        public FEmployeeCustomSchedule(IDEmployeeCustomSchedule iDEmployeeCustomSchedule)
        {
            _iDEmployeeCustomSchedule = iDEmployeeCustomSchedule;
        }

        public async Task<EmployeeCustomSchedule> Add(string loggedUser, EmployeeCustomSchedule employeeCustomSchedule)
        {
            employeeCustomSchedule.CreatedBy = loggedUser;
            employeeCustomSchedule.CreatedOn = DateTime.Now;

            await _iDEmployeeCustomSchedule.Add(employeeCustomSchedule);
            await _iDEmployeeCustomSchedule.Complete();
            return await Task.FromResult(employeeCustomSchedule);
        }

        public async Task<EmployeeCustomSchedule> Edit(string loggedUser, EmployeeCustomSchedule employeeCustomSchedule)
        {
            employeeCustomSchedule.UpdatedBy = loggedUser;
            employeeCustomSchedule.UpdatedOn = DateTime.Now;

            await _iDEmployeeCustomSchedule.Edit(employeeCustomSchedule);
            await _iDEmployeeCustomSchedule.Complete();
            return await Task.FromResult(employeeCustomSchedule);
        }

        public async Task<EmployeeCustomSchedule> Delete(string loggedUser, EmployeeCustomSchedule employeeCustomSchedule)
        {
            employeeCustomSchedule.IsActive = false;
            employeeCustomSchedule.DeletedBy = loggedUser;
            employeeCustomSchedule.DeletedOn = DateTime.Now;

            await _iDEmployeeCustomSchedule.Delete(employeeCustomSchedule);
            await _iDEmployeeCustomSchedule.Complete();

            return await Task.FromResult(employeeCustomSchedule);
        }

        public async Task<EmployeeCustomSchedule> Get(int id)
        {
            return await _iDEmployeeCustomSchedule.Get(x=>x.IsActive == true && x.IDNo == id);
        }
        public async Task<EmployeeCustomSchedule> Get(Func<EmployeeCustomSchedule, bool> condition)
        {
            return await _iDEmployeeCustomSchedule.Get(condition);
        }

        public async Task<List<EmployeeCustomSchedule>> GetAll()
        {
            return await _iDEmployeeCustomSchedule.GetAll(x => x.IsActive == true);
        }

        public async Task<List<EmployeeCustomSchedule>> GetAll(Func<EmployeeCustomSchedule,bool> condition)
        {
            return await _iDEmployeeCustomSchedule.GetAll(condition);
        }
    }
}
