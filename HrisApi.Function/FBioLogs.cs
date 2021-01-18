using HrisApi.Data.Interface; 
using HrisApi.Function.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function
{
    public class FBioLogs : IFBioLogs 
    {
        private readonly IDBioLogs _iDBioLogs;

        public FBioLogs(IDBioLogs iDBioLogs)
        {
            _iDBioLogs = iDBioLogs;
        }
     
        public async Task<BioLogs> Get(int id)
        {
            return await _iDBioLogs.Get(x=>x.IsActive == true && x.IDNo == id);
        }

        public async Task<BioLogs> Get(Func<BioLogs,bool> condition)
        {
            return await _iDBioLogs.Get(condition);
        }

        public async Task<List<BioLogs>> GetAll()
        {
            return await _iDBioLogs.GetAll(x => x.IsActive == true);
        }

        public async Task<List<BioLogs>> GetAll(Func<BioLogs,bool> condition)
        {
            return await _iDBioLogs.GetAll(condition);
        }

    }
}
