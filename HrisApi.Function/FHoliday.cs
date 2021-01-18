using HrisApi.Data.Interface;
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FHoliday : IFHoliday
    {
        private readonly IDHoliday _iDHoliday;

        public FHoliday(IDHoliday iDHoliday)
        {
            _iDHoliday = iDHoliday;
        }

        public async Task<Holiday> Add(string loggedUser, Holiday holiday)
        {
            holiday.CreatedBy = loggedUser;
            holiday.CreatedOn = DateTime.Now;

            await _iDHoliday.Add(holiday);
            await _iDHoliday.Complete();
            return await Task.FromResult(holiday);
        }

        public async Task<Holiday> Edit(string loggedUser,Holiday holiday)
        {
            holiday.UpdatedBy = loggedUser;
            holiday.UpdatedOn = DateTime.Now;

            await _iDHoliday.Edit(holiday);
            await _iDHoliday.Complete();
            return await Task.FromResult(holiday);
        }

        public async Task<Holiday> Delete(string loggedUser, Holiday holiday)
        {
            holiday.IsActive = false;
            holiday.DeletedBy = loggedUser;
            holiday.DeletedOn = DateTime.Now;

            await _iDHoliday.Delete(holiday);
            await _iDHoliday.Complete();
            return await Task.FromResult(holiday);
        }

        public async Task<Holiday> Get(int id)
        {
            return await _iDHoliday.Get(x => x.IsActive == true && x.IDNo == id);
        }

        public async Task<Holiday> Get(Func<Holiday, bool> condition)
        {
            return await _iDHoliday.Get(condition);
        }

        public async Task<List<Holiday>> GetAll()
        {
            return await _iDHoliday.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Holiday>> GetAll(Func<Holiday, bool> condition)
        {
            return await _iDHoliday.GetAll(condition);
        }

        public async Task<int> GetCode(string holidayCode)
        {
            var systemId = _iDHoliday.Get(x => x.IsActive == true && x.HolidayCode == holidayCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
