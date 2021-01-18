
using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Data
{
    public class DEmployeeCustomSchedule : DBase<EmployeeCustomSchedule>,IDEmployeeCustomSchedule
    {
        public DEmployeeCustomSchedule(HrisApiContext db) : base(db)
        {

        }
    }
}
