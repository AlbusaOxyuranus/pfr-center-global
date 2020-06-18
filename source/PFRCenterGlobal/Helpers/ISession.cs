using System;

namespace PFRCenterGlobal.Helpers
{
    public interface ISession
    {
        SessionState SessionState { get; set; }
        DispatcherTimer Timer5 { get; set; }
        DispatcherTimer Timer30 { get; set; }
        TimeSpan SessionTimeout { get; }
        TimeSpan SessionTimeout30 { get; }
        ISessionMethods SessionMethods { get; }
    }
}
