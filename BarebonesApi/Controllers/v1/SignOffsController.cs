using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace UnhingedApi.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class SignOffsController : ControllerBase
{
    // GET: api/SignOffs/All
    [HttpGet]
    [Route("api/[controller]/all")]
    public IActionResult GetAllApprovedSignOffs()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {

            throw;
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
