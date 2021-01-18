using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFBioLogs
    {
        Task<BioLogs> Get(int id);
        Task<BioLogs> Get(Func<BioLogs, bool> condition);
        Task<List<BioLogs>> GetAll();
        Task<List<BioLogs>> GetAll(Func<BioLogs, bool> condition);
    }
}
