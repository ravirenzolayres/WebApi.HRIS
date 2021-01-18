using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFPersonalInfo
    {
        Task<PersonalInfo> Add(string loggedUser, PersonalInfo personalInfo);
        Task<PersonalInfo> Edit(string loggedUser, PersonalInfo personalInfo);
        Task<PersonalInfo> Get(int id);
        Task<PersonalInfo> Get(Func<PersonalInfo,bool> condition);

    }
}
