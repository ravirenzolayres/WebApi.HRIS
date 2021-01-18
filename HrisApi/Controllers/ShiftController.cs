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
    public class ShiftController : ControllerBase
    {
        private readonly IFShift _iFShift;
        private string loggedUser;

        public ShiftController(IFShift iFShift,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFShift = iFShift;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Shift shift)
        {
            var shiftCode = _iFShift.GetCode(shift.ShiftCode);

            if (shiftCode != null)
            {
                ModelState.AddModelError("ShiftCode", shiftCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdShift = await _iFShift.Add(loggedUser, shift);
            return CreatedAtAction(nameof(Get), new { id = createdShift.IDNo }, createdShift);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Shift shift)
        {
            var editShift = await _iFShift.Edit(loggedUser, shift);
            return Ok(editShift);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Shift shift)
        {
            var deleteShift = await _iFShift.Delete(loggedUser, shift);
            return Ok(deleteShift);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Shift> Get(int id)
        {
            return await _iFShift.Get(id);
        }

        [HttpGet]
        public async Task<List<Shift>> GetAll()
        {
            return await _iFShift.GetAll();
        }
        #endregion
    }
}
