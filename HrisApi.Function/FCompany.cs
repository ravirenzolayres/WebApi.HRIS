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
    public class FCompany : IFCompany
    {
        private readonly IDCompany _iDCompany;

        public FCompany(IDCompany iDCompany)
        {
            _iDCompany = iDCompany;
        }

        public async Task<Company> Add(string loggedUser, Company company)
        {
            company.CreatedBy = loggedUser;
            company.CreatedOn = DateTime.Now;

            await _iDCompany.Add(company);
            await _iDCompany.Complete();
            return await Task.FromResult(company);
        }

        public async Task<Company> Edit(string loggedUser,Company company)
        {
            company.UpdatedBy = loggedUser;
            company.UpdatedOn = DateTime.Now;

            await _iDCompany.Edit(company);
            await _iDCompany.Complete();
            return await Task.FromResult(company);
        }

        public async Task<Company> Delete(string loggedUser, Company company)
        {
            company.IsActive = false;
            company.DeletedBy = loggedUser;
            company.DeletedOn = DateTime.Now;

            await _iDCompany.Delete(company);
            await _iDCompany.Complete();
            return await Task.FromResult(company);
        }

        public async Task<Company> Get(int id)
        {
            return await _iDCompany.Get(x => x.IsActive == true && x.IDNo == id);
        }

        public async Task<Company> Get(Func<Company, bool> condition)
        {
            return await _iDCompany.Get(condition);
        }

        public async Task<List<Company>> GetAll()
        {
            return await _iDCompany.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Company>> GetAll(Func<Company, bool> condition)
        {
            return await _iDCompany.GetAll(condition);
        }

        public async Task<int> GetCode(string companyCode)
        {
            var systemId = _iDCompany.Get(x => x.IsActive == true && x.CompanyCode == companyCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
