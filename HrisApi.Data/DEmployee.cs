using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Data
{
    public class DEmployee : DBase<Employee>, IDEmployee
    {
        public DEmployee(HrisApiContext db) : base(db)
        {

        }
    }
}
