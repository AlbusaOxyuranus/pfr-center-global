using System;
using System.Security;
using O2.ToolKit.Core.Commands;

namespace PFRCenterGlobal.ViewModels.Interfaces
{
    public interface IQuestion
    {
        string Question { get; set; }
        IQuestionLogic QuestionLogic { get; set; }
        IAsyncCommand QuestionCommands { get; set; }
        string Address { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        SecureString Password { get; set; }
    }
}
