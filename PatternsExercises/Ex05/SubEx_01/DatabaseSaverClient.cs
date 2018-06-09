using Patterns.Ex05.ExternalLibs;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            var databaseSaver = new DatabaseSaver();
            var mailDecorator = new MailDecorator(databaseSaver, new MailSender());
            var updateDecorator = new CacheDecorator(mailDecorator, new CacheUpdater());
            DoSmth(updateDecorator);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }
    public class MailDecorator : IDatabaseSaver
    {
        private MailSender sender;
        private IDatabaseSaver dbsaver;

        public MailDecorator(IDatabaseSaver dbsaver, MailSender sender)
        {
            this.sender = sender;
            this.dbsaver = dbsaver;
        }

        public void SaveData(object data)
        {
            sender.Send("hello");
            dbsaver.SaveData(null);
        }
    }
    public class CacheDecorator : IDatabaseSaver
    {
        private CacheUpdater updater;
        private IDatabaseSaver dbsaver;

        public CacheDecorator(IDatabaseSaver dbsaver, CacheUpdater updater)
        {
            this.updater = updater;
            this.dbsaver = dbsaver;
        }

        public void SaveData(object data)
        {
            updater.UpdateCache();
            dbsaver.SaveData(null);
        }
    }
}