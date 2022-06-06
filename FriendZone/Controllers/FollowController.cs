using System;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FollowController : ControllerBase
  {
    private readonly FollowsService _fs;

    public FollowController(FollowsService fs)
    {
      _fs = fs;
    }

    [HttpPost]
    public ActionResult<Follow> Create([FromBody] Follow newFollow)
    {
      try
      {
        Follow follow = _fs.Create(newFollow);
        return Ok(follow);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _fs.Delete(id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}