using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Data
{
    public class DHolidayType : DBase<HolidayType>,IDHolidayType
    {
        public DHolidayType(HrisApiContext db) : base(db)
        {

        }
    }
}
