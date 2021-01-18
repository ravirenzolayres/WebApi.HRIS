using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFHoliday
    {
        Task<Holiday> Add(string loggedUser, Holiday holiday);
        Task<Holiday> Edit(string loggedUser,Holiday holiday);
        Task<Holiday> Delete(string loggedUser,Holiday holiday);
        Task<Holiday> Get(int id);
        Task<Holiday> Get(Func<Holiday, bool> condition);
        Task<List<Holiday>> GetAll();
        Task<List<Holiday>> GetAll(Func<Holiday, bool> condition);
        Task<int> GetCode(string holidayCode);
    }
}
