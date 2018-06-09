using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using Patterns.Ex01.ExternalLibs.Twitter;

namespace Patterns.Ex02
{
    public class TwitterUserService : UserService
    {
        readonly TwitterClient _client = new TwitterClient();

        protected override UserInfo[] GetFriends(string userId)
        {
            TwitterUser[] subscribers = _client.GetSubscribers(Int64.Parse(userId));

            UserInfo[] friends = subscribers
                .Select(c =>
                {
                    UserInfo userInfo = new UserInfo
                    {
                        UserId = c.UserId.ToString(),
                        Name = _client.GetUserNameById(c.UserId)
                    };
                    return userInfo;
                })
                .ToArray();
            return friends;
        }
        protected override string GetUserId(string pageUrl)
        {
            var regex = new Regex("twitter.com/(.*)");
            var userName =  regex.Match(pageUrl).Groups[0].Value;
            return GetUserIdByUserName(userName).ToString();
        }
        protected override string GetUserName(string userId)
        {
            return _client.GetUserNameById(Int64.Parse(userId));
        }
        private long GetUserIdByUserName(String userName)
        {
            return _client.GetUserIdByName(userName);
        }
    }
}