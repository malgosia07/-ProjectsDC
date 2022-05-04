using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarin.Models;
using xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPersonPage : ContentPage
    {
        public Person Person { get; set; }
        public AddPersonPage()
        {
            InitializeComponent();
            BindingContext = new AddPersonViewModel();
        }

        public AddPersonPage(Person persona)
        {
            InitializeComponent();
            BindingContext = new AddPersonViewModel();

            if(persona != null)
            {
                ((AddPersonViewModel)BindingContext).Person = persona;
            }
        }

    }
}