using System;
using System.Security;
using System.Threading.Tasks;
using O2.ToolKit.Core;
using O2.ToolKit.Core.Commands;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.ViewModels.Interfaces;
using PFRCenterGlobal.ViewModels.Logic;

namespace PFRCenterGlobal.ViewModels
{
    public class QuestionViewModel :
        ViewModelBase,
        IQuestion,
        IQuestionLogic
    {
        #region Fields
        private string question;
        private string body;
        private string subject;
        private string address;
        private SecureString password;
        #endregion

        #region Props
        public IQuestionLogic QuestionLogic { get; set; }
        public IAsyncCommand QuestionCommands { get; set; }

        public string Address
        {
            get => address; set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public string Subject
        {
            get => subject; set
            {
                subject = value;
                OnPropertyChanged();
            }
        }
        public string Body
        {
            get => body; set
            {
                body = value;
                OnPropertyChanged();
            }
        }
        public SecureString Password
        {
            get => password; set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public string Question
        {
            get => question; set
            {
                question = value;
                OnPropertyChanged();
            }
        }
        #endregion


        public QuestionViewModel()
        {
            QuestionLogic = new QuestionLogic(this);
            QuestionCommands = AsyncCommand.Create(SendQuestionToEmail);
        }

        public async Task SendQuestionToEmail()
        {
            await HelperBussinessProcess.Start(this,
                  async () =>
                  {
                      await QuestionLogic.SendQuestionToEmail();
                  }
               );
        }
    }
}

