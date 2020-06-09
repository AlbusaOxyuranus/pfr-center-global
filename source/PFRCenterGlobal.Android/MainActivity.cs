
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Gms.Common;
using System;
using Android.Widget;
using Firebase.Iid;
using Android.Util;
using Android.Content;
using Android;

namespace PFRCenterGlobal.Droid
{
    [Activity(Label = "PFRCenterGlobal", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        TextView msgText;


        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                // Permissions granted - display a message.

                { }
                else
                // Permissions denied - display a message.
                { }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            IsPlayServiceAvailable();
            var intent = new Intent(this, typeof(MyFirebaseIIDService));
            StartService(intent);
            CreateNotificationChannel();
           
        }

        //private void GetToken()
        //{
        //    var refreshedToken = FirebaseInstanceId.Instance.Token;
        //    Console.WriteLine(TAG, "Refreshed token: " + refreshedToken);
        //}

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
        //    [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        //ToDo: exit app for Android
        //public override void OnBackPressed()
        //{
        //    RunOnUiThread(
        //        async () =>
        //        {
        //            var isCloseApp = await AlertAsync(this, "NameOfApp", "Do you want to close this app?", "Yes", "No");

        //            if (isCloseApp)
        //            {
        //                var activity = (Activity)Forms.Context;
        //                activity.FinishAffinity();
        //            }
        //        });
        //}

        //public Task<bool> AlertAsync(Context context, string title, string message, string positiveButton, string negativeButton)
        //{
        //    var tcs = new TaskCompletionSource<bool>();

        //    using (var db = new AlertDialog.Builder(context))
        //    {
        //        db.SetTitle(title);
        //        db.SetMessage(message);
        //        db.SetPositiveButton(positiveButton, (sender, args) => { tcs.TrySetResult(true); });
        //        db.SetNegativeButton(negativeButton, (sender, args) => { tcs.TrySetResult(false); });
        //        db.Show();
        //    }

        //    return tcs.Task;
        //}

        // check if GoogPlay Serice is available
        public bool IsPlayServiceAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);

            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    // give the user a change to fix the issue
                    // error message
                    Console.WriteLine($"Error : " + GoogleApiAvailability.Instance.GetErrorString(resultCode));
                }
                else
                {
                    // play services not supported message
                    Console.WriteLine($"Error : GoogPlay Serice not supported");
                    Finish();
                }

                return false;
            }
            else
            {
                // services are available message               
                return true;
            }
        }
    }
}