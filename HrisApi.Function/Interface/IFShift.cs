using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFShift
    {
        Task<Shift> Add(string loggedUser, Shift shift);
        Task<Shift> Edit(string loggedUser,Shift shift);
        Task<Shift> Delete(string loggedUser,Shift shift);
        Task<Shift> Get(int id);
        Task<Shift> Get(Func<Shift, bool> condition);
        Task<List<Shift>> GetAll();
        Task<List<Shift>> GetAll(Func<Shift, bool> condition);
        Task<int> GetCode(string shiftCode);
    }
}
