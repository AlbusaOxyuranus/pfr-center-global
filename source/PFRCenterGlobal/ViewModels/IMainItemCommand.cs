using System.Threading.Tasks;
using O2.ToolKit.Core.Commands;

namespace PFRCenterGlobal.ViewModels
{
    public interface IMainItemCommand
    {
        IAsyncCommand OpenUrlCommand
        {
            get;
        }
    }
    public interface IMainItemMethods
    {
        Task OpenUrl();
    }
}