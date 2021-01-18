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
    public class HolidayTypeController : ControllerBase
    {
        private readonly IFHolidayType _iFHolidayType;
        private string loggedUser;

        public HolidayTypeController(IFHolidayType iFHolidayType,IHttpContextAccessor iHttpContextAccessor)
        {
            _iFHolidayType = iFHolidayType;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(HolidayType holidayType)
        {
            var holidayTypeCode = _iFHolidayType.GetCode(holidayType.HolidayTypeCode);

            if (holidayTypeCode != null)
            {
                ModelState.AddModelError("HolidayTypeCode", holidayTypeCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdHolidayType = await _iFHolidayType.Add(loggedUser, holidayType);
            return CreatedAtAction(nameof(Get), new { id = createdHolidayType.IDNo }, createdHolidayType);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(HolidayType holidayType)
        {
            var editHolidayType = await _iFHolidayType.Edit(loggedUser, holidayType);
            return Ok(editHolidayType);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(HolidayType holidayType)
        {
            var deleteHolidayType = await _iFHolidayType.Delete(loggedUser, holidayType);
            return Ok(deleteHolidayType);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<HolidayType> Get(int id)
        {
            return await _iFHolidayType.Get(id);
        }

        [HttpGet]
        public async Task<List<HolidayType>> GetAll()
        {
            return await _iFHolidayType.GetAll();
        }
        #endregion
    }
}
