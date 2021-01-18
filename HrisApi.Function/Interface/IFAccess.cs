using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFAccess
    {
        Task<Access> Add(string loggedUser,Access access);
        Task<Access> Edit(string loggedUser, Access access);
        Task<Access> Delete(string loggedUser, Access access);
        Task<Access> Get(int id);
        Task<Access> Get(Func<Access, bool> condition);
        Task<List<Access>> GetAll();
        Task<List<Access>> GetAll(Func<Access, bool> condition);
        Task<int> GetCode(string accessCode);
    }
}
