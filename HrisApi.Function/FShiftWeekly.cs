using HrisApi.Data.Interface; 
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FShiftWeekly : IFShiftWeekly 
    {
        private readonly IDShiftWeekly _iDShiftWeekly;

        public FShiftWeekly(IDShiftWeekly iDShiftWeekly)
        {
            _iDShiftWeekly = iDShiftWeekly;
        }

        public async Task<ShiftWeekly> Add(string loggedUser, ShiftWeekly ShiftWeekly)
        {
            ShiftWeekly.CreatedBy = loggedUser;
            ShiftWeekly.CreatedOn = DateTime.Now;

            await _iDShiftWeekly.Add(ShiftWeekly);
            await _iDShiftWeekly.Complete();
            return await Task.FromResult(ShiftWeekly);
        }

        public async Task<ShiftWeekly> Edit(string loggedUser, ShiftWeekly ShiftWeekly)
        {
            ShiftWeekly.UpdatedBy = loggedUser;
            ShiftWeekly.UpdatedOn = DateTime.Now;

            await _iDShiftWeekly.Edit(ShiftWeekly);
            await _iDShiftWeekly.Complete();
            return await Task.FromResult(ShiftWeekly);
        }

        public async Task<ShiftWeekly> Delete(string loggedUser, ShiftWeekly ShiftWeekly)
        {
            ShiftWeekly.IsActive = false;
            ShiftWeekly.DeletedBy = loggedUser;
            ShiftWeekly.DeletedOn = DateTime.Now;

            await _iDShiftWeekly.Delete(ShiftWeekly);
            await _iDShiftWeekly.Complete();

            return await Task.FromResult(ShiftWeekly);
        }

        public async Task<ShiftWeekly> Get(int id)
        {
            return await _iDShiftWeekly.Get(x=>x.IsActive == true && x.IDNo == id);
        }
        public async Task<ShiftWeekly> Get(Func<ShiftWeekly, bool> condition)
        {
            return await _iDShiftWeekly.Get(condition);
        }


        public async Task<List<ShiftWeekly>> GetAll()
        {
            return await _iDShiftWeekly.GetAll(x => x.IsActive == true);
        }

        public async Task<List<ShiftWeekly>> GetAll(Func<ShiftWeekly,bool> condition)
        {
            return await _iDShiftWeekly.GetAll(condition);
        }
    }
}
