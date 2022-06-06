using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Profile> GetAll()
    {
      string sql = "SELECT * FROM profiles";
      return _db.Query<Profile>(sql).ToList();
    }

    internal Profile Get(int id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @Id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }
    internal List<ProfileFollowViewModel> GetFollowing(string id)
    {
      string sql = @"
        SELECT * FROM follows
        WHERE follower = @Id";
      return _db.Query<ProfileFollowViewModel>(sql, new { id }).ToList();
    }

    internal List<ProfileFollowViewModel> GetFollowers(string id)
    {
      string sql = @"
        SELECT * FROM follows
        WHERE followed = @Id";
      return _db.Query<ProfileFollowViewModel>(sql, new { id }).ToList();
    }
  }
}