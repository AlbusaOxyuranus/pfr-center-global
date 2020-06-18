using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using O2.ToolKit.Core.Properties;

namespace O2.ToolKit.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for anything
    /// </summary>
    [DataContract]
    public abstract class O2Object : INotifyPropertyChanged
    {
        /// <summary>
        /// Event for notification of changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notification of changes
        /// </summary>
        /// <param name="propertyName"> </param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}