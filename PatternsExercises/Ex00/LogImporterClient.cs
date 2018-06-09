using Patterns.Ex00.ExternalLibs;
namespace Patterns.Ex00
{
    public class LogImporterClient
    {
        //Необходимо сделать возможным использование FtpClient для чтения файла с логами в LogImporter.
        //Сделать это нужно не меняя кода FtpClient, ILogReader и LogImporter
        //Можно менять только LogImporterClient и создавать новые классы\интерфейсы
        /// <summary>
        /// TODO: Изменения нужно вносить в этом методе
        /// </summary>
        public void DoMethod()
        {
            //LogImporter importer = new LogImporter(new FileLogReader());
            //importer.ImportLogs("ftp://log.txt");

            LogImporter importer = new LogImporter(new FtpReader("login", "password"));
            importer.ImportLogs("ftp://log.txt");
        }
    }
    public class FtpReader : ILogReader
    {
        private string login;
        private string password;

        public FtpReader(string login, string pssword)
        {
            this.password = pssword;
            this.login = login;
        }
        public string ReadLogFile(string identificator)
        {
            return new FtpClient().ReadFile(login, password, identificator);
        }
    }
}