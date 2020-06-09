using System;
using System.Net.Mail;
using System.Threading.Tasks;
using PFRCenterGlobal.ViewModels.Interfaces;

namespace PFRCenterGlobal.ViewModels.Logic
{
    public class QuestionLogic : IQuestionLogic
    {
        private readonly IQuestion questionModel;

        public QuestionLogic(IQuestion model)
        {
            questionModel = model;
        }

        public async Task SendQuestionToEmail() =>
            await Task.Run(() =>
            {
                try
                {
                    var mail = new MailMessage();
                    var smtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(questionModel.Address);
                    mail.To.Add(questionModel.Question);
                    mail.Subject = questionModel.Subject;
                    mail.Body = questionModel.Body;

                    smtpServer.Port = 587;
                    smtpServer.Host = "smtp.gmail.com";
                    smtpServer.EnableSsl = true;
                    smtpServer.UseDefaultCredentials = false;
                    smtpServer.Credentials = new System.Net.NetworkCredential(questionModel.Address, questionModel.Password);

                    smtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    //DisplayAlert("Faild", ex.Message, "OK");
                }
            
            });
    }

}
