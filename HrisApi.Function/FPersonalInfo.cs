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
    public class FPersonalInfo : IFPersonalInfo
    {
        private readonly IDPersonalInfo _iDPersonalInfo;

        public FPersonalInfo(IDPersonalInfo iDPersonalInfo)
        {
            _iDPersonalInfo = iDPersonalInfo;
        }

        public async Task<PersonalInfo> Add(string loggedUser, PersonalInfo personalInfo)
        {
            personalInfo.CreatedBy = loggedUser;
            personalInfo.CreatedOn = DateTime.Now;

            await _iDPersonalInfo.Add(personalInfo);
            await _iDPersonalInfo.Complete();
            return await Task.FromResult(personalInfo);
        }

        public async Task<PersonalInfo> Edit(string loggedUser,PersonalInfo personalInfo)
        {
            personalInfo.UpdatedBy = loggedUser;
            personalInfo.UpdatedOn = DateTime.Now;

            await _iDPersonalInfo.Edit(personalInfo);
            await _iDPersonalInfo.Complete();
            return await Task.FromResult(personalInfo);
        }

        public async Task<PersonalInfo> Get(int id)
        {
            return await _iDPersonalInfo.Get(x=>x.IDNo == id);
        }
        public async Task<PersonalInfo> Get(Func<PersonalInfo,bool> condition)
        {
            return await _iDPersonalInfo.Get(condition);
        }
    }
}
