using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PFRCenterGlobal.Helpers
{
    public static class Commander
    {
        private static Dictionary<string, Type>  _registeredRoutes = new Dictionary<string,Type>();

        public static async System.Threading.Tasks.Task GoToAsync(object route)
        {
            if (!_registeredRoutes.Any(x => x.Value == route.GetType()))
            {
                _registeredRoutes.Add(route.ToString(), route.GetType());
                //Routing.RegisterRoute(route.ToString(), route.GetType());
                Routing.RegisterRoute(route.ToString(), route.GetType());
            }
            //foreach (var item in routes)
            //{
            //    Routing.RegisterRoute(item.Key, item.Value);
            //}
            ShellNavigationState state = Shell.Current.CurrentState;
            var itemSearch = _registeredRoutes.First(x => x.Value == route.GetType()).Key;
            await Shell.Current.GoToAsync($"{state.Location}/{route.ToString()}");
            Shell.Current.FlyoutIsPresented = false;
        }
    }

    public class NavigationCommander
    {
        public static Page Current { get; internal set; }
        public static INavigation Navigation { get; internal set; }
        public static App App { get; internal set; }
    }
}
