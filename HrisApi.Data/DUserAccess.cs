using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Data
{
    public class DUserAccess : DBase<UserAccess>,IDUserAccess
    {
        public DUserAccess(HrisApiContext db) : base(db)
        {

        }

    }
}
