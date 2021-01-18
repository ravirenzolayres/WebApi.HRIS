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
    public class FUserAccess : IFUserAccess
    {
        private readonly IDUserAccess _iDUserAccess;

        public FUserAccess(IDUserAccess iDUserAccess)
        {
            _iDUserAccess = iDUserAccess;
        }

        public async Task<UserAccess> Add(string loggedUser, UserAccess userAccess)
        {
            userAccess.CreatedBy = loggedUser;
            userAccess.CreatedOn = DateTime.Now;

            await _iDUserAccess.Add(userAccess);
            await _iDUserAccess.Complete();

            return await Task.FromResult(userAccess);
        }

        public async Task<UserAccess> Edit(string loggedUser, UserAccess userAccess)
        {
            userAccess.UpdatedBy = loggedUser;
            userAccess.UpdatedOn = DateTime.Now;

            await _iDUserAccess.Edit(userAccess);
            await _iDUserAccess.Complete();

            return await Task.FromResult(userAccess);
        }

        public async Task<UserAccess> Get(int id)
        {
            return await _iDUserAccess.Get(x=> x.IDNo == id);
        }
        public async Task<UserAccess> Get(Func<UserAccess, bool> condition)
        {
            return await _iDUserAccess.Get(condition);
        }
        public async Task<List<UserAccess>> GetAll()
        {
            return await _iDUserAccess.GetAll();
        }

        public async Task<List<UserAccess>> GetAll(Func<UserAccess, bool> condition)
        {
            return await _iDUserAccess.GetAll(condition);
        }
    }
}
