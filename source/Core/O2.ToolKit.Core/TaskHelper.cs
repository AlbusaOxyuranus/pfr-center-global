using System;
using System.Threading;
using System.Threading.Tasks;

namespace O2.ToolKit.Core
{
    public static class TaskHelper
    {
        //public static Task RunAsync(Action action)
        //{
        //    var tcs = new TaskCompletionSource<object>();
            
        //    ThreadPool.QueueUserWorkItem(_ =>
        //    {
        //        try
        //        {
        //            action();
        //            tcs.SetResult(null);
        //        }
        //        catch (Exception exc)
        //        {
        //            tcs.SetException(exc);
        //        }
        //    });
        //    return tcs.Task;
        //}
    }
}
