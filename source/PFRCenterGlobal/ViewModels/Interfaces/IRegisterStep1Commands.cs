using System.Windows.Input;
using O2.ToolKit.Core.Commands;

namespace PFRCenterGlobal.ViewModels
{
    internal interface IRegisterStep2Commands
    {
        IAsyncCommand GoRegisterStep3Command { get; }
        IAsyncCommand GoBackRegisterStep1Command { get; }
    }

    internal interface IRegisterStep1Commands
    {
        /// <summary>
        /// Перейти к шагу 2
        /// </summary>
        IAsyncCommand GoRegisterStep2Command { get; }
        /// <summary>
        /// Перейти к экрану вводу существующего аккаунта
        /// </summary>
        IAsyncCommand GoExistUserCommand { get; }
        /// <summary>
        /// Открыть лицензионное соглашение
        /// </summary>
        IAsyncCommand GoLicenceCommand { get; }
        /// <summary>
        /// Открыть соглашение ДБО
        /// </summary>
        IAsyncCommand GoLicenceDBOCommand { get; }
    }
}