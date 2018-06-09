using System;
using System.Collections.Generic;
using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_02
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            var databaseSaver = new DBSaverClient();
            databaseSaver.RegisterAction(() => new MailSender().Send("Hello"));
            databaseSaver.RegisterAction(() => new CacheUpdater().UpdateCache());
            DoSmth(databaseSaver);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }

    public class DBSaverClient : IDatabaseSaver
    {
        private List<Action> actions = new List<Action>();

        public void SaveData(object data)
        {
            //Сохранение данных в БД
            Notify();
        }
        public void RegisterAction(Action action)
        {
            actions.Add(action);
        }
        private void Notify()
        {
            foreach (var action in actions)
                action.Invoke();
        }
    }
}