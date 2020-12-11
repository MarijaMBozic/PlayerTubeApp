using Server.DTO;
using Server.Helper.Exeptions.MailExeption;
using Server.Helper.Exeptions.UserExeption;
using Server.Helper.SendEmail;
using Server.Repository.Interface;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Server.Service
{
    public class SubscriberService : ISubscriberService
    {
        ISubscriberRepository _repository { get; set; }

        public SubscriberService(ISubscriberRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SubscriberDTO> GetAllSubscribersByUser(int userId)
        {
            return _repository.GetAllSubscribersEmailByUser(userId);
        }

        public void Insert(SubscriberDTO subscriber)
        {
            if(!(_repository.CheckSubscription(subscriber)))
            {
                _repository.Insert(subscriber);
            }
            else
            {
                throw new AlreadySubscribedExeption();
            }
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public void SendEmail(string email, string userName, string videoName)
        {
            try
            {
                EmailHelper emailData = new EmailHelper();
                string emailFrom = emailData.emailFrom;
                string password = emailData.password;
                MailMessage mm = new MailMessage(emailFrom, email);
                mm.Subject = "New videos";
                mm.Body =string.Format("User {0} posted new video {1} on his playerTuce channel", userName, videoName);
                mm.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential(emailFrom, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
            }
            catch
            {
                throw new SendEmailExeption();
            }
        }
    }
}