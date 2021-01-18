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
    public class PositionController : ControllerBase
    {
        private readonly IFPosition _iFPosition;
        private string loggedUser;

        public PositionController(IFPosition iFPosition, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFPosition = iFPosition;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Position position)
        {
            var positionCode = _iFPosition.GetCode(position.PositionCode);

            if (positionCode != null)
            {
                ModelState.AddModelError("PositionCode", positionCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdPosition =  await _iFPosition.Add(loggedUser, position);
            return CreatedAtAction(nameof(Get), new { id = createdPosition.IDNo }, createdPosition);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Position position)
        {
            var editPosition = await _iFPosition.Edit(loggedUser, position);
            return Ok(editPosition);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Position position)
        {
            var deletePosition = await _iFPosition.Delete(loggedUser, position);
            return Ok(deletePosition);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Position> Get(int id)
        {
            return await _iFPosition.Get(id);
        }

        [HttpGet]
        public async Task<List<Position>> GetAll()
        {
            return await _iFPosition.GetAll();
        }
        #endregion
    }
}
