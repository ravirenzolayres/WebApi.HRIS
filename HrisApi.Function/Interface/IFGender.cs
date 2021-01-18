using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFGender
    {
        Task<Gender> Add(string loggedUser, Gender gender);
        Task<Gender> Edit(string loggedUser,Gender gender);
        Task<Gender> Delete(string loggedUser,Gender gender);
        Task<Gender> Get(int id);
        Task<Gender> Get(Func<Gender, bool> condition);
        Task<List<Gender>> GetAll();
        Task<List<Gender>> GetAll(Func<Gender,bool> condition);
        Task<int> GetCode(string genderCode);
    }
}
