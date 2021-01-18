using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFHolidayType
    {
        Task<HolidayType> Add(string loggedUser, HolidayType holidayType);
        Task<HolidayType> Edit(string loggedUser,HolidayType holidayType);
        Task<HolidayType> Delete(string loggedUser,HolidayType holidayType);
        Task<HolidayType> Get(int id);
        Task<HolidayType> Get(Func<HolidayType, bool> condition);
        Task<List<HolidayType>> GetAll();
        Task<List<HolidayType>> GetAll(Func<HolidayType, bool> condition);
        Task<int> GetCode(string holidayTypeCode);
    }
}
