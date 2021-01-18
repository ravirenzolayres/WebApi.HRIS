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
    public class FBranch : IFBranch
    {
        private readonly IDBranch _iDBranch;

        public FBranch(IDBranch iDBranch)
        {
            _iDBranch = iDBranch;
        }

        public async Task<Branch> Add(string loggedUser, Branch branch)
        {
            branch.CreatedBy = loggedUser;
            branch.CreatedOn = DateTime.Now;

            await _iDBranch.Add(branch);
            await _iDBranch.Complete();
            return await Task.FromResult(branch);
        }

        public async Task<Branch> Edit(string loggedUser,Branch branch)
        {
            branch.UpdatedBy = loggedUser;
            branch.UpdatedOn = DateTime.Now;

            await _iDBranch.Edit(branch);
            await _iDBranch.Complete();
            return await Task.FromResult(branch);
        }

        public async Task<Branch> Delete(string loggedUser, Branch branch)
        {

            branch.IsActive = false;
            branch.DeletedBy = loggedUser;
            branch.DeletedOn = DateTime.Now;

            await _iDBranch.Delete(branch);
            await _iDBranch.Complete();
            return await Task.FromResult(branch);
        }

        public async Task<Branch> Get(int id)
        {
            return await _iDBranch.Get(x => x.IsActive == true && x.IDNo == id);
        }

        public async Task<Branch> Get(Func<Branch,bool> condition)
        {
            return await _iDBranch.Get(condition);
        }

        public async Task<List<Branch>> GetAll()
        {
            return await _iDBranch.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Branch>> GetAll(Func<Branch, bool> condition)
        {
            return await _iDBranch.GetAll(condition);
        }

        public async Task<int> GetCode(string branchCode)
        {
            var systemId = _iDBranch.Get(x => x.IsActive == true && x.BranchCode == branchCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
