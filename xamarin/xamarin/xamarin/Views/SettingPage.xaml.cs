using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarin.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            switch (Settings.Theme)
            {
   
                case 0:
                    RadioButtonLight.IsChecked = true;
                    break;
                case 1:
                    RadioButtonDark.IsChecked = true;
                    break;
            }


        }

        bool loaded;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loaded = true;
        }

        private void RadioButtonSystem_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!loaded)
                return;

            if (!e.Value)
                return;

            var val = (sender as RadioButton)?.Value as string;
            if (string.IsNullOrWhiteSpace(val))
                return;

            switch (val)
            {
               
                case "Light":
                    Settings.Theme = 0;
                    break;
                case "Dark":
                    Settings.Theme = 1;
                    break;
            }

            Theme.SetTheme();
        }
    }
}