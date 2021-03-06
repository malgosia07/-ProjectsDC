using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace xamarin.Helper
{
    public static class Theme
    {
        public static void SetTheme()
        {
            switch (Settings.Theme)
            {
                
                
                //light
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            var nav = App.Current.MainPage as Xamarin.Forms.NavigationPage;

            var e = DependencyService.Get<IEnvironment>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                e?.SetStatusBarColor(Color.Black, false);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.Black;
                    nav.BarTextColor = Color.White;
                }
            }
            else
            {
                e?.SetStatusBarColor(Color.White, true);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.White;
                    nav.BarTextColor = Color.Black;
                }
            }

        }

    }
}
