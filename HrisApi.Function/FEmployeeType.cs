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
    public class FEmployeeType : IFEmployeeType 
    {
        private readonly IDEmployeeType _iDEmployeeType;


        public FEmployeeType(IDEmployeeType iDEmployeeType)
        {
            _iDEmployeeType = iDEmployeeType;
        }

        public async Task<EmployeeType> Add(string loggedUser, EmployeeType employeeType)
        {
            employeeType.CreatedBy = loggedUser;
            employeeType.CreatedOn = DateTime.Now;

            await _iDEmployeeType.Add(employeeType);
            await _iDEmployeeType.Complete();
            return await Task.FromResult(employeeType);
        }

        public async Task<EmployeeType> Edit(string loggedUser,EmployeeType employeeType)
        {
            employeeType.UpdatedBy = loggedUser;
            employeeType.UpdatedOn = DateTime.Now;

            await _iDEmployeeType.Edit(employeeType);
            await _iDEmployeeType.Complete();
            return await Task.FromResult(employeeType);
        }

        public async Task<EmployeeType> Delete(string loggedUser, EmployeeType employeeType)
        {
            employeeType.IsActive = false;
            employeeType.DeletedBy = loggedUser;
            employeeType.DeletedOn = DateTime.Now;

            await _iDEmployeeType.Delete(employeeType);
            await _iDEmployeeType.Complete();
            return await Task.FromResult(employeeType);
        }

        public async Task<EmployeeType> Get(int id)
        {
            return await _iDEmployeeType.Get(x=>x.IsActive == true && x.IDNo == id);
        }
        public async Task<EmployeeType> Get(Func<EmployeeType, bool> condition)
        {
            return await _iDEmployeeType.Get(condition);
        }

        public async Task<List<EmployeeType>> GetAll()
        {
            return await _iDEmployeeType.GetAll(x => x.IsActive == true);
        }

        public async Task<List<EmployeeType>> GetAll(Func<EmployeeType,bool> condition)
        {
            return await _iDEmployeeType.GetAll(condition);
        }

        public async Task<int> GetCode(string employeeTypeCode)
        {
            var systemId = _iDEmployeeType.Get(x => x.IsActive == true && x.EmployeeTypeCode == employeeTypeCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
