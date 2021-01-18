using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFShiftWeekly
    {
        Task<ShiftWeekly> Add(string loggedUser, ShiftWeekly shiftWeekly);
        Task<ShiftWeekly> Edit(string loggedUser,ShiftWeekly shiftWeekly);
        Task<ShiftWeekly> Delete(string loggedUser,ShiftWeekly shiftWeekly);
        Task<ShiftWeekly> Get(int id);
        Task<ShiftWeekly> Get(Func<ShiftWeekly, bool> condition);
        Task<List<ShiftWeekly>> GetAll();
        Task<List<ShiftWeekly>> GetAll(Func<ShiftWeekly, bool> condition);
    }
}
