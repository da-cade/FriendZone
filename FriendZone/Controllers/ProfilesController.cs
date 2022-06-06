using System;
using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly FollowsService _fs;

    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<List<Profile>> GetAll()
    {
      try
      {
        List<Profile> profiles = _ps.GetAll();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(int id)
    {
      try
      {
        Profile profile = _ps.Get(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/followedby")]
    public ActionResult<List<ProfileFollowViewModel>> GetFollowers(string id)
    {
      try
      {
        List<ProfileFollowViewModel> followersList = _ps.GetFollowers(id);
        return Ok(followersList);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}