using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonListPage : ContentPage
    {
        PersonListViewModel personListViewModel;
        public PersonListPage()
        {
            InitializeComponent();
            BindingContext = personListViewModel = new PersonListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            personListViewModel.OnAppearing();
        }
    }
}