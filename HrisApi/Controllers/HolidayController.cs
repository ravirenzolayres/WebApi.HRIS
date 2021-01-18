using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrisApi.Function.Interface;
using HrisApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IFHoliday _iFHoliday;
        private string loggedUser;

        public HolidayController(IFHoliday iFHoliday,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFHoliday = iFHoliday;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Holiday holiday)
        {
            var holidayCode = _iFHoliday.GetCode(holiday.HolidayCode);

            if (holidayCode != null)
            {
                ModelState.AddModelError("HolidayCode", holidayCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdHoliday = await _iFHoliday.Add(loggedUser, holiday);
            return CreatedAtAction(nameof(Get), new { id = createdHoliday.IDNo }, createdHoliday);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Holiday holiday)
        {
            var editHoliday = await _iFHoliday.Edit(loggedUser, holiday);
            return Ok(editHoliday);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Holiday holiday)
        {
            var deleteHoliday = await _iFHoliday.Delete(loggedUser, holiday);
            return Ok(deleteHoliday);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Holiday> Get(int id)
        {
            return await _iFHoliday.Get(id);
        }

        [HttpGet]
        public async Task<List<Holiday>> GetAll()
        {
            return await _iFHoliday.GetAll();
        }
        #endregion
    }
}
