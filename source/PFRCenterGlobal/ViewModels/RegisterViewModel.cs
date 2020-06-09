using System.Threading.Tasks;
using O2.ToolKit.Core;
using O2.ToolKit.Core.Commands;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.Views;
using PFRCenterGlobal.Views.AuthZone;
using PFRCenterGlobal.Views.Register;
using Xamarin.Forms;

namespace PFRCenterGlobal.ViewModels
{
    public interface IRegisterStep2
    {
        ///// <summary>
        ///// Полный логин пользователя вида 375447987208
        ///// </summary>
        //string FullLogin { get; }

        IRegisterStep2Methods RegisterStep2Methods { get; }

    }

    public class RegisterStep2Logic : IRegisterStep2Methods
    {

        public RegisterStep2Logic(IRegisterStep2 registerStep2)
        {
            RegisterStep2 = registerStep2;
        }

        public IRegisterStep2 RegisterStep2 { get; set; }

        public bool CanGoRegisterStep3()
        {
            return true;
        }

        public async Task GoRegisterStep3()
        {
            //await Task.Delay(100);

            //RegisterHelper.CodeSMSValidation(RegisterStep2);
            //NavigationManager.Instance.Navigate(typeof(RegisterStep3View));
            await NavigationCommander.Navigation.PushAsync(new Register3Page());
        }


    }
    public interface IRegisterStep1Methods
    {
        Task GoRegisterStep2();
        bool CanGoRegisterStep2();
        //Task GoLicence();
        //Task GoExistUser();
        //Task GoLicenceDBO();
    }
    public interface IRegisterStep2Methods
    {
        Task GoRegisterStep3();
        bool CanGoRegisterStep3();
    }

    public interface IRegisterStep1
    {

    }
    public interface IRegisterStep3 {
    }

    public interface IRegisterStep3Methods
    {
        Task GoRegisterStepFinish();
        bool CanGoRegisterStepFinishAsync();
    }

    public class RegisterStep3Logic : IRegisterStep3Methods
    {
        public IRegisterStep3 RegisterStep3 { get; set; }
        public RegisterStep3Logic(IRegisterStep3 registerStep1)
        {
            this.RegisterStep3 = registerStep1;
        }
        public async Task GoRegisterStepFinish()
        {

            //await NavigationCommander.Navigation.PushAsync(new StartPage());
            NavigationCommander.App.MainPage = new AppShell();
            //await Commander.GoToAsync(new HomePage());
            //ShellNavigationState state = Shell.Current.CurrentState;
            //await NavigationCommander.Navigation.PushAsync(new AppShell());
            //NavigationCommander.Current = new Register2Page();
            //Application.Current
            //await Shell.Current.Navigation.PushAsync(new Register2Page());
            //Shell.Current.FlyoutIsPresented = false;
        }



        public bool CanGoRegisterStepFinishAsync()
        {
            return true;
        }
    }

        public class RegisterStep1Logic : IRegisterStep1Methods
        {
            public IRegisterStep1 RegisterStep1 { get; set; }
            public RegisterStep1Logic(IRegisterStep1 registerStep1)
            {
                this.RegisterStep1 = registerStep1;
            }

            public async Task GoRegisterStep2()
            {

                await NavigationCommander.Navigation.PushAsync(new Register2Page());

                //NavigationCommander.Current = new Register2Page();
                //Application.Current
                //await Shell.Current.Navigation.PushAsync(new Register2Page());
                //Shell.Current.FlyoutIsPresented = false;
            }

            public bool CanGoRegisterStep2()
            {
                return true;
            }
        }
    

        public class RegisterViewModel : ViewModelBase,
            IRegisterStep1,
            IRegisterStep2,
            IRegisterStep3,
        IRegisterStep1Commands,
        IRegisterStep2Commands
        {

            public IRegisterStep1Methods RegisterStep1Methods { get; }
            public IRegisterStep2Methods RegisterStep2Methods { get; }
            public IRegisterStep3Methods RegisterStep3Methods { get; }

            #region implementation IRegisterStep1Commands

            public IAsyncCommand GoRegisterStep2Command { get; }
            public IAsyncCommand GoExistUserCommand { get; }
            public IAsyncCommand GoLicenceCommand { get; }
            public IAsyncCommand GoLicenceDBOCommand { get; }

            #endregion


            #region IRegisterStep2Commands

            public IAsyncCommand GoRegisterStep3Command { get; }
            public IAsyncCommand GoBackRegisterStep1Command { get; }

            #endregion

            #region IRegisterStep3Commands

            public IAsyncCommand GoRegisterStepFinishCommand { get; }
            public IAsyncCommand GoBackRegisterStep2Command { get; }

            #endregion

            public RegisterViewModel()
            {
                RegisterStep1Methods = new RegisterStep1Logic(this);
                RegisterStep2Methods = new RegisterStep2Logic(this);
                RegisterStep3Methods = new RegisterStep3Logic(this);
                GoRegisterStep2Command = AsyncCommand.Create(GoRegisterStep2, CanGoRegisterStep2);
                GoRegisterStep3Command = AsyncCommand.Create(GoRegisterStep3, CanGoRegisterStep3);
                GoRegisterStepFinishCommand = AsyncCommand.Create(GoRegisterStepFinish, CanGoRegisterStepFinish);
            }

            private bool CanGoRegisterStepFinish()
            {
                return RegisterStep2Methods.CanGoRegisterStep3();
            }

            private async Task GoRegisterStepFinish()
            {
                await HelperBussinessProcess.Start(this,
                      async () =>
                      {
                          await RegisterStep3Methods.GoRegisterStepFinish();
                      }
                   );
            }

            private bool CanGoRegisterStep3()
            {
                return RegisterStep2Methods.CanGoRegisterStep3();
            }

            private async Task GoRegisterStep3()
            {
                await HelperBussinessProcess.Start(this,
                      async () =>
                      {
                          await RegisterStep2Methods.GoRegisterStep3();
                      }
                   );
            }

            public async Task GoRegisterStep2()
            {
                await HelperBussinessProcess.Start(this,
                      async () =>
                      {
                          await RegisterStep1Methods.GoRegisterStep2();
                      }
                   );
            }

            public bool CanGoRegisterStep2()
            {
                return RegisterStep1Methods.CanGoRegisterStep2();
            }
        
    }
}
