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
    public class FEducationInfo : IFEducationInfo
    {
        private readonly IDEducationInfo _iDEducationInfo;

        public FEducationInfo(IDEducationInfo iDEducationInfo)
        {
            _iDEducationInfo = iDEducationInfo;
        }

        public async Task<EducationInfo> Add(string loggedUser, EducationInfo educationInfo)
        {
            educationInfo.CreatedBy = loggedUser;
            educationInfo.CreatedOn = DateTime.Now;

            await _iDEducationInfo.Add(educationInfo);
            await _iDEducationInfo.Complete();
            return await Task.FromResult(educationInfo);
        }

        public async Task<EducationInfo> Edit(string loggedUser, EducationInfo educationInfo)
        {
            educationInfo.UpdatedBy = loggedUser;
            educationInfo.UpdatedOn = DateTime.Now;

            await _iDEducationInfo.Edit(educationInfo);
            await _iDEducationInfo.Complete();
            return await Task.FromResult(educationInfo);
        }

        public async Task<EducationInfo> Get(int id)
        {
            return await _iDEducationInfo.Get(x=>x.IDNo == id);
        }

        public async Task<EducationInfo> Get(Func<EducationInfo, bool> condition)
        {
            return await _iDEducationInfo.Get(condition);
        }
        public async Task<List<EducationInfo>> GetAll()
        {
            return await _iDEducationInfo.GetAll();
        }

        public async Task<List<EducationInfo>> GetAll(Func<EducationInfo, bool> condition)
        {
            return await _iDEducationInfo.GetAll(condition);
        }
    }
}
