using System;
using Patterns.Ex01.ExternalLibs.Instagram;
using System.Collections.Generic;
using System.Linq;
using Patterns.Ex01.ExternalLibs.Twitter;

namespace Patterns.Ex01
{
    public interface SubscribeGetter
    {
        SocialNetworkUser[] GetSubscribers(String userName);
    }
    public class SubscriberViewer
    {
        private Dictionary<SocialNetwork, SubscribeGetter> subscribeGetters;

        public SubscriberViewer()
        {
            subscribeGetters = new Dictionary<SocialNetwork, SubscribeGetter>();
        }
        public void AddSocialNetwork(SocialNetwork socialNetwork, SubscribeGetter subscribeGetter)
        {
            subscribeGetters[socialNetwork] = subscribeGetter;
        }
        /// <summary>
        /// Возвращает список подписчиков пользователя из соц.сети.
        /// TODO: необходимо изменить этот метод по условиям задачи
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="networkType"></param>
        /// <returns></returns>

        public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        {
            return subscribeGetters[networkType].GetSubscribers(userName);
        }
    }

    public class InstgramGetter : SubscribeGetter
    {
        private InstagramClient client;
        public InstgramGetter(InstagramClient client)
        {
            this.client = client;
        }
        public SocialNetworkUser[] GetSubscribers(String userName)
        {
            return client.GetSubscribers(userName)
                         .Select(user => new SocialNetworkUser() { UserName = user.UserName })
                         .ToArray();
        }
    }
    public class TwitterGetter : SubscribeGetter
    {
        private TwitterClient client;
        public TwitterGetter(TwitterClient client)
        {
            this.client = client;
        }
        public SocialNetworkUser[] GetSubscribers(String userName)
        {          
            return client.GetSubscribers(client.GetUserIdByName(userName))
                         .Select(user => new SocialNetworkUser()
                         { UserName = client.GetUserNameById(user.UserId) })
                         .ToArray();
        }
    }
}