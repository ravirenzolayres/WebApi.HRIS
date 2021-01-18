using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFCivilStatus
    {
        Task<CivilStatus> Add(string loggedUser, CivilStatus civilStatus);
        Task<CivilStatus> Edit(string loggedUser,CivilStatus civilStatus);
        Task<CivilStatus> Delete(string loggedUser,CivilStatus civilStatus);
        Task<CivilStatus> Get(int id);
        Task<CivilStatus> Get(Func<CivilStatus, bool> condition);
        Task<List<CivilStatus>> GetAll();
        Task<List<CivilStatus>> GetAll(Func<CivilStatus,bool> condition);
        Task<int> GetCode(string civilStatusCode);
    }
}
