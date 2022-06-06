using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal List<Profile> GetAll()
    {
      List<Profile> profiles = _repo.GetAll();
      return profiles;
    }
    internal Profile Get(int id)
    {
      Profile profile = _repo.Get(id);
      return profile;
    }
    internal List<ProfileFollowViewModel> GetFollowingByProfile(string id)
    {
      List<ProfileFollowViewModel> followingList = _repo.GetFollowing(id);
      return followingList;
    }

    internal List<ProfileFollowViewModel> GetFollowers(string id)
    {
      List<ProfileFollowViewModel> followersList = _repo.GetFollowers(id);
      return followersList;
    }
  }
}