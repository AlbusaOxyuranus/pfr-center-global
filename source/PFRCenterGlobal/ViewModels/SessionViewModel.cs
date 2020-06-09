using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using O2.ToolKit.Core;
using O2.ToolKit.Core.Commands;
using PFRCenterGlobal.Helpers;
using PFRCenterGlobal.Models;
using PFRCenterGlobal.Views;
using Xamarin.Forms;

namespace PFRCenterGlobal.ViewModels
{

    [DataContract]
    public class SuspensionSessionViewModel: ViewModelBase
    {
        [DataMember]
        public string NameView { get; set; }
    }

    public class SessionLogic : ISessionMethods
    {
        public async Task GoLogout()
        {
            await Task.Delay(100);
            await EndSession();
            NavigationManager.Instance.NavigateAsync(typeof(LogonPage));
        }

        public async Task EndSession()
        {
            if (SessionViewModel.Instance.SessionState == SessionState.New ||
                SessionViewModel.Instance.SessionState == SessionState.Pause)
            {
                await Task.Delay(100);
                SessionViewModel.Instance.Timer5.Stop();
                SessionViewModel.Instance.SessionState = SessionState.Close;
                SessionViewModel.Instance.Timer30.Stop();
            }
        }

        public async Task StartSession()
        {
            SessionViewModel.Instance.SessionState = SessionState.New;
            await Task.Delay(100);
            SessionViewModel.Instance.Timer5.Start();
            SessionViewModel.Instance.Timer30.Start();
        }


        public async Task PauseSession()
        {
            await Task.Delay(100);
            SessionViewModel.Instance.SessionState = SessionState.Pause;
            SessionViewModel.Instance.Timer5.Stop();
            await O2Store.SaveState(DependencyService.Get<IFileWorker>());
            SuspensionSessionViewModel suspensionSessionView = new SuspensionSessionViewModel
            {
                NameView = NavigationManager.Instance.FrameType
            };
            // ToDo: uncommnt
            //suspensionSessionView.SerializeDataContractAsync();
            //NavigationManager.Instance.NavigateAsync(typeof(LogonPage));
        }

        public async Task RestoreSession()
        {
            await Task.Delay(100);
            SuspensionSessionViewModel suspensionSession = O2Serializer.DeserializeDataContract<SuspensionSessionViewModel>();
            var typeName = suspensionSession.NameView;
           NavigationManager.Instance.NavigateAsync(suspensionSession.NameView);
        }

        public async Task UpdateSession()
        {
            await Task.Delay(1);
            SessionViewModel.Instance.Timer5.Stop();
            SessionViewModel.Instance.Timer5.Start();
            SessionViewModel.Instance.Timer30.Stop();
            SessionViewModel.Instance.Timer30.Start();
        }
    }

    public class SessionViewModel :
        ViewModelBase, ISession, ISessionCommands, ISessionMethods
    {
        public string Id { get; set; }
        private static volatile SessionViewModel _instance;
        private static readonly object SyncRoot = new Object();

        public static SessionViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SessionViewModel();
                            _instance.SessionMethods = new SessionLogic();
                            _instance.StartSessionCommand = AsyncCommand.Create(async () => { await _instance.StartSession(); });
                            _instance.EndSessionCommand = AsyncCommand.Create(async () => { await _instance.EndSession(); });
                            _instance.LogoutCommand = AsyncCommand.Create(async () => { await _instance.GoLogout(); });
                            _instance.PauseSessionCommand = AsyncCommand.Create(async () => { await _instance.PauseSession(); });
                            _instance.UpdateSessionCommand = AsyncCommand.Create(async () => { await _instance.UpdateSession(); });
                            _instance.SessionTimeout = TimeSpan.FromMinutes(5);
                            _instance.SessionTimeout30 = TimeSpan.FromMinutes(30);
                            //_instance.SessionTimeout = TimeSpan.FromSeconds(15);
                            //_instance.SessionTimeout30 = TimeSpan.FromSeconds(120);
                            _instance.Timer5 = new DispatcherTimer();
                            _instance.Timer5.Interval = _instance.SessionTimeout;
                            _instance.Timer5.Tick += Timer5_Tick;
                            _instance.Timer30 = new DispatcherTimer();
                            _instance.Timer30.Interval = _instance.SessionTimeout30;
                            _instance.Timer30.Tick += Timer30_Tick;
                        }
                    }
                }

                return _instance;
            }
        }

        public async Task UpdateSession()
        {

            await SessionMethods.UpdateSession();
            Debug.WriteLine("Dev Windows Phone Log:<< UpdateSession");
        }

        private static async void Timer30_Tick(object sender, EventArgs e)
        {

            await _instance.EndSession();
            Debug.WriteLine("Dev Windows Phone Log:<< EndSession");
        }

        private static async void Timer5_Tick(object sender, EventArgs e)
        {

            await _instance.PauseSession();
            Debug.WriteLine("Dev Windows Phone Log:<< PauseSession");
        }

        public async Task PauseSession()
        {
            //Проверяем не запущена ли TASK
            if (!_instance.BussinessProcess)
            {
                _instance.BussinessProcess = true;
                try
                {
                    await _instance.SessionMethods.PauseSession();
                    await Task.Delay(100);
                    _instance.BussinessProcess = false;
                }
                catch (Exception exception)
                {
                    _instance.BussinessProcess = false;
                    throw new Exception(exception.Message, exception);
                }
            }
        }

        public async Task RestoreSession()
        {
            //Проверяем не запущена ли TASK
            if (!_instance.BussinessProcess)
            {
                _instance.BussinessProcess = true;
                try
                {
                    await _instance.SessionMethods.RestoreSession();
                    await Task.Delay(100);
                    _instance.BussinessProcess = false;
                }
                catch (Exception exception)
                {
                    _instance.BussinessProcess = false;
                    throw new Exception(exception.Message, exception);
                }
            }
        }

        public async Task GoLogout()
        {
            //Проверяем не запущена ли TASK
            if (!_instance.BussinessProcess)
            {
                _instance.BussinessProcess = true;
                try
                {
                    await _instance.SessionMethods.GoLogout();
                    await Task.Delay(100);
                    _instance.BussinessProcess = false;
                }
                catch (Exception exception)
                {
                    _instance.BussinessProcess = false;
                    throw new Exception(exception.Message, exception);
                }
            }
        }

        public async Task EndSession()
        {
            //Проверяем не запущена ли TASK
            if (!_instance.BussinessProcess)
            {
                _instance.BussinessProcess = true;
                try
                {
                    await _instance.SessionMethods.EndSession();
                    await Task.Delay(100);
                    _instance.BussinessProcess = false;
                }
                catch (Exception exception)
                {
                    _instance.BussinessProcess = false;
                    throw new Exception(exception.Message, exception);
                }
            }
        }

        public async Task StartSession()
        {
            Debug.WriteLine("Dev Windows Phone Log:<< StartSession");
            //Проверяем не запущена ли TASK
            if (!_instance.BussinessProcess)
            {
                _instance.BussinessProcess = true;
                try
                {
                    await _instance.SessionMethods.StartSession();
                    await Task.Delay(100);
                    _instance.BussinessProcess = false;
                }
                catch (Exception exception)
                {
                    _instance.BussinessProcess = false;
                    throw new Exception(exception.Message, exception);
                }
            }
        }

        public void SetId(SessionModel sessionModel)
        {
            Id = sessionModel.Id;
        }


        public IAsyncCommand UpdateSessionCommand { get; set; }
        public IAsyncCommand StartSessionCommand { get; set; }
        public IAsyncCommand PauseSessionCommand { get; set; }
        public IAsyncCommand EndSessionCommand { get; set; }
        public IAsyncCommand LogoutCommand { get; set; }
        public SessionState SessionState { get; set; }
        public DispatcherTimer Timer5 { get; set; }
        public DispatcherTimer Timer30 { get; set; }
        public TimeSpan SessionTimeout { get; set; }
        public TimeSpan SessionTimeout30 { get; set; }
        public ISessionMethods SessionMethods { get; set; }

    }
}
