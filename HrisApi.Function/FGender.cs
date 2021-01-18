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
    public class FGender : IFGender 
    {
        private readonly IDGender _iDGender;
        public FGender(IDGender IDGender)
        {
            _iDGender = IDGender;
        }

        public async Task<Gender> Add(string loggedUser, Gender gender)
        {
            gender.CreatedBy = loggedUser;
            gender.CreatedOn = DateTime.Now;

            await _iDGender.Add(gender);
            await _iDGender.Complete();
            return await Task.FromResult(gender);
        }


        public async Task<Gender> Edit(string loggedUser,Gender gender)
        {
            gender.UpdatedBy = loggedUser;
            gender.UpdatedOn = DateTime.Now;

            await _iDGender.Edit(gender);
            await _iDGender.Complete();
            return await Task.FromResult(gender);
        }

        public async Task<Gender> Delete(string loggedUser, Gender gender)
        {
            gender.IsActive = false;
            gender.DeletedBy = loggedUser;
            gender.DeletedOn = DateTime.Now;

            await _iDGender.Delete(gender);
            await _iDGender.Complete();
            return await Task.FromResult(gender);
        }
        public async Task<Gender> Get(int id)
        {
            return await _iDGender.Get(x=>x.IsActive == true && x.IDNo == id);
        }

        public async Task<Gender> Get(Func<Gender, bool> condition)
        {
            return await _iDGender.Get(condition);
        }

        public async Task<List<Gender>> GetAll()
        {
            return await _iDGender.GetAll(x=>x.IsActive == true);

        }
        public async Task<List<Gender>> GetAll(Func<Gender,bool> condition)
        {
            return await _iDGender.GetAll(condition);
            
        }

        public async Task<int> GetCode(string genderCode)
        {
            var systemId = _iDGender.Get(x => x.IsActive == true && x.GenderCode == genderCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
