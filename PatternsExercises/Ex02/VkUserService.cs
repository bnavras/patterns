namespace Patterns.Ex02
{
    public class VkUserService : UserService
    {
        protected override UserInfo[] GetFriends(string userId)
        {
            return new UserInfo[0];
        }
        protected override string GetUserId(string pageUrl)
        {
            return "USER_ID";
        }
        protected override string GetUserName(string userId)
        {
            return "NAME";        
        }
    }
}