using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftWeeklyController : ControllerBase
    {
        private readonly IFShiftWeekly _iFShiftWeekly;
        private string loggedUser;

        public ShiftWeeklyController(IFShiftWeekly iFShiftWeekly,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFShiftWeekly = iFShiftWeekly;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(ShiftWeekly shiftWeekly)
        {
            var createdShiftWeekly = await _iFShiftWeekly.Add(loggedUser, shiftWeekly);
            return CreatedAtAction(nameof(Get), new { id = createdShiftWeekly.IDNo }, createdShiftWeekly);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(ShiftWeekly shiftWeekly)
        {
            var editShiftWeekly = await _iFShiftWeekly.Edit(loggedUser, shiftWeekly);
            return Ok(editShiftWeekly);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(ShiftWeekly shiftWeekly)
        {
            var deleteShiftWeekly = await _iFShiftWeekly.Delete(loggedUser, shiftWeekly);
            return Ok(deleteShiftWeekly);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<ShiftWeekly> Get(int id)
        {
            return await _iFShiftWeekly.Get(id);
        }

        [HttpGet]
        public async Task<List<ShiftWeekly>> GetAll()
        {
            return await _iFShiftWeekly.GetAll();
        }
        #endregion
    }
}
