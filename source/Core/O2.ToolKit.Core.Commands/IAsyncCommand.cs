using System.Threading.Tasks;
using System.Windows.Input;

namespace O2.ToolKit.Core.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}