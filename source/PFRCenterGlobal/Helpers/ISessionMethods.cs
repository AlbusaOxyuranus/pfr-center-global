using System.Threading.Tasks;

namespace PFRCenterGlobal.Helpers
{
    public interface ISessionMethods
    {
        Task GoLogout();
        Task EndSession();
        Task StartSession();
        Task PauseSession();
        Task RestoreSession();
        Task UpdateSession();
    }
}
