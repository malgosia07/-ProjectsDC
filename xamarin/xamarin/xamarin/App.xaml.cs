using System;
using xamarin.Services;
using xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using xamarin.Helper;
using Xamarin.Essentials;

namespace xamarin
{
    public partial class App : Application
    {
        static PersonService _personService;
        public static PersonService PersonService
        {
            get
            {
                if(_personService == null)
                {
                    _personService = new PersonService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Person.db3"));
                }
                return _personService;

            }
            
        }

       

        public App()
        {
            InitializeComponent();
           

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            Theme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            Theme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
               Theme.SetTheme();
            });
        }
    }
}
