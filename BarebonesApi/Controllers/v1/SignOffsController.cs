using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnhingedLibrary.DataAccess;
using UnhingedLibrary.Models;

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
    [Route("all")]
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

    // GET api/<SignOffsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<SignOffsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<SignOffsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SignOffsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
