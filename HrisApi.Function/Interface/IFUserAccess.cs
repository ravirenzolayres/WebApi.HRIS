using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFUserAccess
    {
        Task<UserAccess> Add(string loggedUser, UserAccess userAccess);
        Task<UserAccess> Edit(string loggedUser,UserAccess userAccess);
        Task<UserAccess> Get(int id);
        Task<UserAccess> Get(Func<UserAccess, bool> condition);
        Task<List<UserAccess>> GetAll();
        Task<List<UserAccess>> GetAll(Func<UserAccess, bool> condition);
    }
}
