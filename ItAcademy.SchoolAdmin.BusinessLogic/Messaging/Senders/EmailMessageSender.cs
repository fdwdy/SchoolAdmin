using System;
using System.Net;
using System.Net.Mail;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging.Senders
{
    public class EmailMessageSender : IMessageSender, IMessageHandler
    {
        private bool _isException;

        public EmailMessageSender()
        {
            _isException = new Random().Next(1, 101) > 66;
        }

        public bool IsProperContactAvailable(Employee emp)
        {
            return string.IsNullOrEmpty(emp.Email) ? false : true;
        }

        public Result<Message> Process(Message msg, Employee emp)
        {
            if (!IsProperContactAvailable(emp))
            {
                msg.Status = Enums.MessageStatus.Invalid;
                return Result<Message>.Fail(msg, "There is no contact available for this employee.");
            }

            try
            {
                return Send(msg, emp);
            }
            catch
            {
                msg.Status = Enums.MessageStatus.Error;
                return Result<Message>.Fail(msg, "Error occurred while sending message to employee");
            }
        }

        public Result<Message> Send(Message msg, Employee emp)
        {
            if (_isException)
            {
                throw new Exception("Random error.");
            }

            string senderEmail = "sd483mbxfv@gmail.com";
            string password = "11111111q~";
            SmtpClient smt = ConfigureGmailSmtpClient(senderEmail, password);
            smt.Send(CreateMessage(msg, emp, senderEmail, "Message from SchoolAdmin"));
            msg.Status = Enums.MessageStatus.Ok;
            return Result<Message>.Ok(msg);
        }

        private SmtpClient ConfigureGmailSmtpClient(string username, string password)
        {
            NetworkCredential ntwd = new NetworkCredential
            {
                UserName = username,
                Password = password
            };

            SmtpClient smt = new SmtpClient
            {
                Host = "smtp.gmail.com",
                UseDefaultCredentials = true,
                Credentials = ntwd,
                Port = 587,
                EnableSsl = true,
            };

            return smt;
        }

        private MailMessage CreateMessage(Message msg, Employee emp, string senderAddress, string subject)
        {
            MailMessage mmsg = new MailMessage
            {
                From = new MailAddress(senderAddress),
                Subject = subject,
                Body = msg.Text,
            };
            mmsg.To.Add(new MailAddress(emp.Email));
            return mmsg;
        }
    }
}
