using Domain.Entities;
using System.Collections.Generic;

namespace LeitorDeCaixaDeEmail.Entities
{
    public class MailBox
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Email> Emails { get; set; }

        public MailBox(string host, int port, bool ssl, string userName, string password)
        {
            Host = host;
            Port = port;
            Ssl = ssl;
            UserName = userName;
            Password = password;
            Emails = new List<Email>();
        }

    }
}
