using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFCompany
    {
        Task<Company> Add(string loggedUser, Company company);
        Task<Company> Edit(string loggedUser,Company company);
        Task<Company> Delete(string loggedUser,Company company);
        Task<Company> Get(int id);
        Task<Company> Get(Func<Company, bool> condition);
        Task<List<Company>> GetAll();
        Task<List<Company>> GetAll(Func<Company, bool> condition);
        Task<int> GetCode(string companyCode);
    }
}
