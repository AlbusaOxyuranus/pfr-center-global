using System;
using System.Threading.Tasks;

namespace PFRCenterGlobal.ViewModels.Interfaces
{
    public interface IAccount
    {
        string Username { get; set; }
        string PhoneNumber { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string AccountId { get; set; }
    }

    interface IAccountLogic
    {
        Task SaveChanges();
        Task SavePassword();
    }
}
