namespace Patterns.Ex02
{
    public abstract class UserService
    {
        protected abstract string GetUserName(string pageUri);
        protected abstract string GetUserId(string pageUri);
        protected abstract UserInfo[] GetFriends(string id);
        public UserInfo GetUserInfo(string pageUir)
        {
            var userId = GetUserId(pageUir);
            var userName = GetUserName(userId);
            var friends = GetFriends(userId);
           
            var result = new UserInfo
            {
                Name = userName,
                UserId = userId,
                Friends = friends
            };
            return result;
        }
    }
}
