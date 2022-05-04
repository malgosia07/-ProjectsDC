using System;
using System.Collections.Generic;
using System.Text;
using xamarin.Models;
using Xamarin.Forms;

namespace xamarin.ViewModels
{
    public class AddPersonViewModel:BasePersonViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        

        public AddPersonViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            Person = new Person();
        }

        private async void OnSave()
        {
            var person = Person;
            await App.PersonService.AddPersonAsync(person);

            await Shell.Current.GoToAsync("..");

        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
