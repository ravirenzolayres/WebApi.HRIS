using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFUser
    {
        Task<User> Add(string loggedUser,User user);
        Task<User> Edit(string loggedUser, User user);
        Task<User> Delete(string loggedUser, User user);
        Task<User> Get(int id);
        Task<User> Get(Func<User, bool> condition);
        Task<List<User>> GetAll();
        Task<List<User>> GetAll(Func<User, bool> condition);
        Task<int> GetCode(string username);

    }
}
