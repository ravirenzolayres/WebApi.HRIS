using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Data
{
    public class DPersonalInfo : DBase<PersonalInfo>, IDPersonalInfo
    {
        public DPersonalInfo(HrisApiContext db) : base(db)
        {

        }
    }
}
