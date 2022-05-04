using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using xamarin.Models;
using Xamarin.Forms;

namespace xamarin.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string chapters;
        private string volumes;
        private string episodes;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(chapters)
                && !String.IsNullOrWhiteSpace(volumes)
                && !String.IsNullOrWhiteSpace(episodes);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Chapters
        {
            get => chapters;
            set => SetProperty(ref chapters, value);
        }
        public string Volumes
        {
            get => volumes;
            set => SetProperty(ref volumes, value);
        }
        public string Episodes
        {
            get => episodes;
            set => SetProperty(ref episodes, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Chapters = Chapters,
                Volumes = Volumes,
                Episodes = Episodes,
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
