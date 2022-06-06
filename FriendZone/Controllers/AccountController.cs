using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly ProfilesService _profilesService;

    public AccountController(AccountService accountService, ProfilesService profilesService)
    {
      _accountService = accountService;
      _profilesService = profilesService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("following")]
    public async Task<ActionResult<List<ProfileFollowViewModel>>> GetFollowing()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<ProfileFollowViewModel> followingList = _profilesService.GetFollowingByProfile(userInfo.Id);
        return Ok(followingList);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}