
using HrisApi.Context;
using HrisApi.Data.DBase;
using HrisApi.Data.Interface;
using HrisApi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrisApi.Data
{
    public class DShiftWeekly : DBase<ShiftWeekly>,IDShiftWeekly
    {
        public DShiftWeekly(HrisApiContext db) : base(db)
        {

        }
    }
}
