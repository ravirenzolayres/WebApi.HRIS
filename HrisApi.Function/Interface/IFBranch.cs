using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFBranch
    {
        Task<Branch> Add(string loggedUser, Branch branch);
        Task<Branch> Edit(string loggedUser,Branch branch);
        Task<Branch> Delete(string loggedUser,Branch branch);
        Task<Branch> Get(int id);
        Task<Branch> Get(Func<Branch, bool> condition);
        Task<List<Branch>> GetAll();
        Task<List<Branch>> GetAll(Func<Branch, bool> condition);
        Task<int> GetCode(string branchCode);
    }
}
