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
    public class BranchController : ControllerBase
    {
        private readonly IFBranch _iFBranch;
        private string loggedUser;

        public BranchController(IFBranch iFBranch, IHttpContextAccessor iHttpContextAccessor)
        {
            _iFBranch = iFBranch;
            loggedUser = iHttpContextAccessor.HttpContext.User.Identity.Name;
        }

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add(Branch branch)
        {
            var branchCode = _iFBranch.GetCode(branch.BranchCode);

            if (branchCode != null)
            {
                ModelState.AddModelError("BranchCode", branchCode + " is already in use. ");
                return BadRequest(ModelState);
            }

            var createdBranch =  await _iFBranch.Add(loggedUser,branch);
            return CreatedAtAction(nameof(Get), new { id = createdBranch.IDNo }, createdBranch);
        }
        #endregion

        #region Edit
        [HttpPut]
        public async Task<IActionResult> Edit(Branch branch)
        {
            var editBranch = await _iFBranch.Edit(loggedUser,branch);
            return Ok(editBranch);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(Branch branch)
        {
            var deleteBranch = await _iFBranch.Delete(loggedUser,branch);
            return Ok(deleteBranch);
        }
        #endregion

        #region Get
        [HttpGet("{id}")]
        public async Task<Branch> Get(int id)
        {
            return await _iFBranch.Get(id);
        }

        [HttpGet]
        public async Task<List<Branch>> GetAll()
        {
            return await _iFBranch.GetAll();
        }
        #endregion
    }
}
