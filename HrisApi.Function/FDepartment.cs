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
    public class FDepartment : IFDepartment
    {
        private readonly IDDepartment _iDDepartment;

        public FDepartment(IDDepartment iDDepartment)
        {
            _iDDepartment = iDDepartment;
        }

        public async Task<Department> Add(string loggedUser, Department department)
        {
            department.CreatedBy = loggedUser;
            department.CreatedOn = DateTime.Now;

            await _iDDepartment.Add(department);
            await _iDDepartment.Complete();
            return await Task.FromResult(department);
        }

        public async Task<Department> Edit(string loggedUser,Department department)
        {
            department.UpdatedBy = loggedUser;
            department.UpdatedOn = DateTime.Now;

            await _iDDepartment.Edit(department);
            await _iDDepartment.Complete();
            return await Task.FromResult(department);
        }

        public async Task<Department> Delete(string loggedUser, Department department)
        {
            department.IsActive = false;
            department.DeletedBy = loggedUser;
            department.DeletedOn = DateTime.Now;

            await _iDDepartment.Delete(department);
            await _iDDepartment.Complete();
            return await Task.FromResult(department);
        }

        public async Task<Department> Get(int id)
        {
            return await _iDDepartment.Get(x => x.IsActive == true && x.IDNo == id);
        }

        public async Task<Department> Get(Func<Department, bool> condition)
        {
            return await _iDDepartment.Get(condition);
        }

        public async Task<List<Department>> GetAll()
        {
            return await _iDDepartment.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Department>> GetAll(Func<Department, bool> condition)
        {
            return await _iDDepartment.GetAll(condition);
        }

        public async Task<int> GetCode(string departmentCode)
        {
            var systemId = _iDDepartment.Get(x => x.IsActive == true && x.DepartmentCode == departmentCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
