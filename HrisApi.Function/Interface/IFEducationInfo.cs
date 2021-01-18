using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFEducationInfo
    {
        Task<EducationInfo> Add(string loggedUser, EducationInfo educationInfo);
        Task<EducationInfo> Edit(string loggedUser,EducationInfo educationInfo);
        Task<EducationInfo> Get(int id);
        Task<EducationInfo> Get(Func<EducationInfo, bool> condition);
        Task<List<EducationInfo>> GetAll();
        Task<List<EducationInfo>> GetAll(Func<EducationInfo, bool> condition);

    }
}
