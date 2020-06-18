using O2.ToolKit.Core.Commands;

namespace PFRCenterGlobal.Helpers
{
    interface ISessionCommands
    {
        IAsyncCommand UpdateSessionCommand { get; }
        IAsyncCommand StartSessionCommand { get; }
        IAsyncCommand PauseSessionCommand { get; }
        IAsyncCommand EndSessionCommand { get; }
        IAsyncCommand LogoutCommand { get; }
    }
}
