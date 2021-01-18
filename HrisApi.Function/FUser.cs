using HrisApi.Data.Interface;
using HrisApi.Function.Interface;
using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FUser : IFUser
    {
        private readonly IDUser _iDUser;

        public FUser(IDUser iDUser)
        {
            _iDUser = iDUser;
        }

        public async Task<User> Add(string loggedUser, User user)
        {
            user.CreatedBy = loggedUser;
            user.CreatedOn = DateTime.Now;

            await _iDUser.Add(user);
            await _iDUser.Complete();
            return await Task.FromResult(user);
        }

        public async Task<User> Edit(string loggedUser, User user)
        {
            user.UpdatedBy = loggedUser;
            user.UpdatedOn = DateTime.Now;

            await _iDUser.Edit(user);
            await _iDUser.Complete();
            return await Task.FromResult(user);
        }

        public async Task<User> Delete(string loggedUser, User user)
        {
            user.IsActive = false;
            user.DeletedBy = loggedUser;
            user.DeletedOn = DateTime.Now;

            await _iDUser.Delete(user);
            await _iDUser.Complete();
            return await Task.FromResult(user);
        }

        public async Task<User> Get(int id)
        {
            return await _iDUser.Get(x => x.IsActive == true && x.IDNo == id);
        }
        public async Task<User> Get(Func<User, bool> condition)
        {
            return await _iDUser.Get(condition);
        }

        public async Task<List<User>> GetAll()
        {
            return await _iDUser.GetAll(x => x.IsActive == true);
        }

        public async Task<List<User>> GetAll(Func<User, bool> condition)
        {
            return await _iDUser.GetAll(condition);
        }

        public async Task<int> GetCode(string username)
        {
            var systemId = _iDUser.Get(x => x.IsActive == true && x.Username == username).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
