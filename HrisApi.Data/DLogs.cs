
using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Data
{
    public class DBioLogs : DBase<BioLogs>, IDBioLogs
    {
        public DBioLogs(HrisApiContext db) : base(db)
        {

        }


    }
}
