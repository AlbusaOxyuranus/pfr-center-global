using System;
using Xamarin.Forms;

namespace PFRCenterGlobal.Helpers
{
    public class DispatcherTimer
    {
        bool IsWork { get; set; }
        public DispatcherTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(Interval.TotalSeconds), () =>
            {
                //if (Tick != null)
                //    Tick.DynamicInvoke(null);
                // что-то делаем здесь...
                ;
                return IsWork; // True = повторить снова, False = остановить таймер
            });
        }
        internal void Stop()
        {
            IsWork = false;
        }

        internal void Start()
        {
            IsWork = true;
        }

        public TimeSpan Interval { get; set; }
        public Action<object, EventArgs> Tick { get; set; }
    }
}
