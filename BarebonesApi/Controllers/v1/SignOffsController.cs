using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnhingedApi.Models;
using UnhingedLibrary.DataAccess;
using UnhingedLibrary.Models;
using YamlDotNet.Core.Tokens;

namespace UnhingedApi.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class SignOffsController : ControllerBase
{
    private readonly ISignOffData _data;

    public SignOffsController(ISignOffData data)
    {
        _data = data;
    }

    // GET: api/SignOffs/All
    [HttpGet]
    [Route("All")]
    [AllowAnonymous]
    public async Task<ActionResult<List<SignOffModel>>> GetAllApprovedSignOffs()
    {
        try
        {
            List<SignOffModel> output = await _data.LoadAllApprovedSignOffs();
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/SignOffs/ToApprove
    [HttpGet]
    [Route("ToApprove")]
    [AllowAnonymous]
    public async Task<ActionResult<List<SignOffModel>>> GetSignOffsToApprove()
    {
        try
        {
            List<SignOffModel> output = await _data.LoadAllSignOffsToBeApproved();
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/SignOffs/Deleted
    [HttpGet]
    [Route("Deleted")]
    [AllowAnonymous]
    public async Task<ActionResult<List<SignOffModel>>> GetDeletedSignOffs()
    {
        try
        {
            List<SignOffModel> output = await _data.LoadAllSignDeletedSignOffs();
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/SignOffs
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<SignOffModel>>> GetRandomSignOff()
    {
        try
        {
            List<SignOffModel> output = await _data.LoadRandomSignOff();
            return Ok(output);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // POST: api/SignOffs
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> PostSignOff([FromBody] VerifySignOffModel signOff)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _data.CreateSignOff(signOff.SignOff, signOff.Author);
                return Ok("New Uninged sign off added successfully, please wait for admin approval :)");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PATCH: api/SignOffs/{Id}/Approve
    [HttpPatch]
    [Route("{id}/Approve")]
    [AllowAnonymous]
    public async Task<IActionResult> PatchApproveSignOff(int id)
    {
        try
        {
            await _data.ApproveSignOff(id);
            return Ok("Sign Off approved successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PATCH: api/SignOffs/{Id}
    [HttpPatch]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> EditSignOff([FromBody] VerifySignOffModel signOff, int id)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _data.AmendSignOff(signOff.SignOff, signOff.Author, id);
                return Ok("Sign Off edit successful!");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/SignOffs/{Id}
    [HttpDelete]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteSignOffById(int id)
    {
        try
        {
            await _data.DeleteSignOff(id);
            return Ok("Sign Off deleted successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
