using Domain.Entities;
using LeitorDeCaixaDeEmail.Entities;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace PrimeiroRobo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var parametros = _configuration.GetSection("ParametrosCaixaDeEmail");
                var intervalo = _configuration.GetSection("Configuracoes").GetValue<int>("IntervaloExecucao");

                string host = parametros.GetValue<string>("Host");
                int port = parametros.GetValue<int>("Port");
                bool ssl = parametros.GetValue<bool>("Ssl");
                string user = parametros.GetValue<string>("User");
                string password = parametros.GetValue<string>("Password");

                while (!stoppingToken.IsCancellationRequested)
                {
                    var mailBox = new MailBox(host, port, ssl, user, password);

                    try
                    {
                        using (var client = new ImapClient())
                        {
                            client.Connect(mailBox.Host, mailBox.Port, mailBox.Ssl);
                            client.Authenticate(mailBox.UserName, mailBox.Password);
                            client.Timeout = 300000;

                            client.Inbox.Open(FolderAccess.ReadWrite);

                            var inBox = client.Inbox.Search(SearchQuery.All);

                            foreach (var menssage in inBox)
                            {
                                string path = "";
                                try
                                {
                                    MimeMessage message = new MimeMessage();
                                    message = client.Inbox.GetMessage(menssage);

                                    Email email = new Email(message.From.ToString(), message.To.ToString(), message.Subject, message.Body.ToString());
                                    mailBox.Emails.Add(email);

                                    bool temAnexo = false;
                                    foreach (var attachment in message.Attachments)
                                    {
                                        temAnexo = true;
                                        var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;

                                        if (fileName == null)
                                            break;

                                        if (fileName.ToLower().Contains(".xml"))
                                        {
                                            using (var stream = File.Create(fileName))
                                            {
                                                if (attachment is MessagePart)
                                                {
                                                    var rfc822 = (MessagePart)attachment;

                                                    rfc822.Message.WriteTo(stream);
                                                }
                                                else
                                                {
                                                    var part = (MimePart)attachment;
                                                    part.Content.DecodeTo(stream);
                                                    path = stream.Name;
                                                }
                                            }

                                            XmlDocument xml = new XmlDocument();
                                            xml.Load(path);

                                            File.Delete(path);
                                        }

                                        Console.WriteLine($"{menssage} - {message.From} - {message.Date}");
                                    }
                                }
                                catch (Exception e)
                                {
                                    File.Delete(path);
                                    client.Disconnect(true);
                                    throw e;
                                }
                            }

                            client.Disconnect(true);
                        }

                        await Task.Delay(intervalo, stoppingToken);
                    }
                    catch (Exception e)
                    {
                        await Task.Delay(3000, stoppingToken);
                    }
                }
            }
        }
    }
}
