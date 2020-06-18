using System;
using System.Threading.Tasks;
using O2.ToolKit.Core;

namespace PFRCenterGlobal.Helpers
{
    public static class HelperBussinessProcess
    {
        public static async Task Start(ViewModelBase vm, Func<Task> operationsFunc)
        {
            if (!vm.BussinessProcess)
            {
                vm.BussinessProcess = true;
                try
                {
                    await operationsFunc();
                    await Task.Delay(100);
                    vm.BussinessProcess = false;
                }
                catch (Exception ex)
                {
                    vm.BussinessProcess = false;
                    throw;
                }
            }
        }
    }
}
