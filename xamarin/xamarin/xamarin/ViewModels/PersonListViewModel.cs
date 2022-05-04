using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using xamarin.Models;
using xamarin.ViewModels;
using xamarin.Views;
using Xamarin.Forms;

namespace xamarin.ViewModels
{
    public class PersonListViewModel : BasePersonViewModel
    {
        public Command LoadPersonCommand { get; }
        public ObservableCollection<Person> Person { get; }

        public Command AddPersonCommand { get; }
        public Command PersonTappedEdit { get; }
        public Command PersonTappedDelete { get; }

        public PersonListViewModel(INavigation _nav)
        {
            LoadPersonCommand = new Command(async () => await ExecuteLoadPersonCommand());
            Person = new ObservableCollection<Person>();
            AddPersonCommand = new Command(OnAddPerson);
            PersonTappedEdit = new Command<Person>(OnEditPerson);
            PersonTappedDelete = new Command<Person>(OnDeletePerson);
            Navigation = _nav;
        }

        

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadPersonCommand()
        {
            try
            {
                IsBusy = true;
                Person.Clear();
                var persList = await App.PersonService.GetPersonAsync();
                foreach (var pers in persList)
                {
                    Person.Add(pers);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }  
        }

        private async void OnAddPerson(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddPersonPage));
        }

        private async void OnEditPerson(Person per)
        {
            await Navigation.PushAsync(new AddPersonPage(per));
        }

        private async void OnDeletePerson(Person per)
        {
            if(per == null)
            {
                return;
            }
            var res = await App.Current.MainPage.DisplayAlert("Delete", $"Delete {per.NamePerson} from the datebase", "Yes", "No");
            if (res)
            {
                await App.PersonService.DeletePersonAsync(per.IdPerson);
                await ExecuteLoadPersonCommand();
            }

            //await App.PersonService.DeletePersonAsync(per.IdPerson);
            //await ExecuteLoadPersonCommand();
        }
    }
}
