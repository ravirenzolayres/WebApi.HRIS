using HrisApi.Data.Interface; 
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FAccess : IFAccess 
    {
        private readonly IDAccess _iDAccess;

        public FAccess(IDAccess iDAccess)
        {
            _iDAccess = iDAccess;
        }
        public async Task<Access> Add(string loggedUser,Access access)
        {
            access.CreatedBy = loggedUser;
            access.CreatedOn = DateTime.Now;
            await _iDAccess.Add(access);
            //await _iDAccess.Complete();
            return await Task.FromResult(access);
        }

        public async Task<Access> Edit(string loggedUser, Access access)
        {
            access.UpdatedBy = loggedUser;
            access.UpdatedOn = DateTime.Now;

            await _iDAccess.Edit(access);
            //await _iDAccess.Complete();
            return await Task.FromResult(access);
        }

        public async Task<Access> Delete(string loggedUser, Access access)
        {
            access.IsActive = false;
            access.DeletedBy = loggedUser;
            access.DeletedOn = DateTime.Now;

            await _iDAccess.Delete(access);
            //await _iDAccess.Complete();

            return await Task.FromResult(access);
        }

        public async Task<Access> Get(int id)
        {
            return await _iDAccess.Get(x=>x.IsActive == true && x.IDNo == id);
        }

        public async Task<Access> Get(Func<Access,bool> condition)
        {
            return await _iDAccess.Get(condition);
        }

        public async Task<List<Access>> GetAll()
        {
            return await _iDAccess.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Access>> GetAll(Func<Access,bool> condition)
        {
            return await _iDAccess.GetAll(condition);
        }

        public async Task<int> GetCode(string accessCode)
        {
            var systemId = _iDAccess.Get(x => x.IsActive == true && x.AccessCode == accessCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }

    }
}
