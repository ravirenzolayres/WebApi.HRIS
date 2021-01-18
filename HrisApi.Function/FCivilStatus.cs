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
    public class FCivilStatus : IFCivilStatus
    {
        private readonly IDCivilStatus _iDCivilStatus;

        public FCivilStatus(IDCivilStatus iDCivilStatus)
        {
            _iDCivilStatus = iDCivilStatus;
        }

        public async Task<CivilStatus> Add(string loggedUser, CivilStatus civilStatus)
        {
            civilStatus.CreatedBy = loggedUser;
            civilStatus.CreatedOn = DateTime.Now;

            await _iDCivilStatus.Add(civilStatus);
            await _iDCivilStatus.Complete();
            return await Task.FromResult(civilStatus);
        }

        public async Task<CivilStatus> Edit(string loggedUser, CivilStatus civilStatus)
        {
            civilStatus.UpdatedBy = loggedUser;
            civilStatus.UpdatedOn = DateTime.Now;

            await _iDCivilStatus.Edit(civilStatus);
           await  _iDCivilStatus.Complete();
            return await Task.FromResult(civilStatus);
        }

        public async Task<CivilStatus> Delete(string loggedUser, CivilStatus civilStatus)
        {
            civilStatus.IsActive = false;
            civilStatus.DeletedBy = loggedUser;
            civilStatus.DeletedOn = DateTime.Now;

            await _iDCivilStatus.Delete(civilStatus);
            await _iDCivilStatus.Complete();
            return await Task.FromResult(civilStatus);
        }

        public async Task<CivilStatus> Get(int id)
        {
            return await _iDCivilStatus.Get(x=>x.IsActive == true && x.IDNo == id);
        }
        public async Task<CivilStatus> Get(Func<CivilStatus,bool> condition)
        {
            return await _iDCivilStatus.Get(condition);
        }
        public async Task<List<CivilStatus>> GetAll()
        {
            return await _iDCivilStatus.GetAll(x=>x.IsActive == true);
        }

        public async Task<List<CivilStatus>> GetAll(Func<CivilStatus,bool> condition)
        {
            return await _iDCivilStatus.GetAll(condition);
        }

        public async Task<int> GetCode(string civilStatusCode)
        {
            var systemId = _iDCivilStatus.Get(x => x.IsActive == true && x.CivilStatusCode == civilStatusCode).Result.IDNo;
            return await Task.FromResult(systemId);
        }
    }
}
