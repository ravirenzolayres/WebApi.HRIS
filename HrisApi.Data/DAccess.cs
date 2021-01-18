
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
    public class DAccess : DBase<Access>, IDAccess
    {
        public DAccess(HrisApiContext db) : base(db)
        {

        }

        //public async new Task<Access> Add(Access access)
        //{
        //    return await Task.FromResult(access);
        //}

        //public async new Task<Access> Edit(Access access)
        //{
        //    return await Task.FromResult(access);
        //}

        //public async new Task<Access> Delete(Access access)
        //{
        //    return await Task.FromResult(access);
        //}

    }
}
