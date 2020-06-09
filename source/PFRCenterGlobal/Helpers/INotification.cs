using System;

namespace PFRCenterGlobal.Helpers
{
    public interface INotification
    {
        void CreateNotification(String title, String message);
    }
}