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
    public class FHolidayType : IFHolidayType
    {
        private readonly IDHolidayType _iDHolidayType;

        public FHolidayType(IDHolidayType iDHolidayType)
        {
            _iDHolidayType = iDHolidayType;
        }

        public async Task<HolidayType> Add(string loggedUser, HolidayType holidayType)
        {
            holidayType.CreatedBy = loggedUser;
            holidayType.CreatedOn = DateTime.Now;

            await _iDHolidayType.Add(holidayType);
            await _iDHolidayType.Complete();
            return await Task.FromResult(holidayType);
        }

        public async Task<HolidayType> Edit(string loggedUser,HolidayType holidayType)
        {
            holidayType.UpdatedBy = loggedUser;
            holidayType.UpdatedOn = DateTime.Now;

            await _iDHolidayType.Edit(holidayType);
            await _iDHolidayType.Complete();
            return await Task.FromResult(holidayType);
        }

        public async Task<HolidayType> Delete(string loggedUser, HolidayType holidayType)
        {

            holidayType.IsActive = false;
            holidayType.DeletedBy = loggedUser;
            holidayType.DeletedOn = DateTime.Now;

            await _iDHolidayType.Delete(holidayType);
            await _iDHolidayType.Complete();
            return await Task.FromResult(holidayType);
        }

        public async Task<HolidayType> Get(int id)
        {
            return await _iDHolidayType.Get(x => x.IsActive == true && x.IDNo == id);
        }

        public async Task<HolidayType> Get(Func<HolidayType, bool> condition)
        {
            return await _iDHolidayType.Get(condition);
        }
        public async Task<List<HolidayType>> GetAll()
        {
            return await _iDHolidayType.GetAll(x => x.IsActive == true);
        }

        public async Task<List<HolidayType>> GetAll(Func<HolidayType, bool> condition)
        {
            return await _iDHolidayType.GetAll(condition);
        }

        public async Task<int> GetCode(string holidayTypeCode)
        {
            var systemId = _iDHolidayType.Get(x => x.IsActive == true && x.HolidayTypeCode == holidayTypeCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
