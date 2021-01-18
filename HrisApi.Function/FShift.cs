using HrisApi.Data.Interface; 
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FShift : IFShift 
    {
        private readonly IDShift _iDShift;

        public FShift(IDShift iDShift)
        {
            _iDShift = iDShift;
        }

        public async Task<Shift> Add(string loggedUser, Shift shift)
        {
            shift.CreatedBy = loggedUser;
            shift.CreatedOn = DateTime.Now;

            await _iDShift.Add(shift);
            await _iDShift.Complete();
            return await Task.FromResult(shift);
        }

        public async Task<Shift> Edit(string loggedUser, Shift shift)
        {

            shift.UpdatedBy = loggedUser;
            shift.UpdatedOn = DateTime.Now;

            await _iDShift.Edit(shift);
            await _iDShift.Complete();
            return await Task.FromResult(shift);
        }

        public async Task<Shift> Delete(string loggedUser, Shift shift)
        {
            shift.IsActive = false;
            shift.DeletedBy = loggedUser;
            shift.DeletedOn = DateTime.Now;

            await _iDShift.Delete(shift);
            await _iDShift.Complete();

            return await Task.FromResult(shift);
        }

        public async Task<Shift> Get(int id)
        {
            return await _iDShift.Get(x=>x.IsActive == true && x.IDNo == id);
        }
        public async Task<Shift> Get(Func<Shift, bool> condition)
        {
            return await _iDShift.Get(condition);
        }


        public async Task<List<Shift>> GetAll()
        {
            return await _iDShift.GetAll(x => x.IsActive == true);
        }

        public async Task<List<Shift>> GetAll(Func<Shift,bool> condition)
        {
            return await _iDShift.GetAll(condition);
        }

        public async Task<int> GetCode(string shiftCode)
        {
            var systemId = _iDShift.Get(x => x.IsActive == true && x.ShiftCode == shiftCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
