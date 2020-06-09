using System;
using O2.ToolKit.Core.Commands;

namespace PFRCenterGlobal.ViewModels.Interfaces
{
    public interface ICertificate
    {
        ICertificateLogic CertificateLogic { get; set; }
        IAsyncCommand OpenCertificateAsyncCommand { get; }

        Guid Id { get; set; }
        string Number { get; set; }
        int ShortNumber { get; set; }
    }
}
