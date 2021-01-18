using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Data
{
    public class DHoliday : DBase<Holiday>,IDHoliday
    {
        public DHoliday(HrisApiContext db) : base(db)
        {

        }
    }
}
