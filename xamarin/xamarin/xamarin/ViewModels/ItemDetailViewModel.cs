using System;
using System.Diagnostics;
using System.Threading.Tasks;
using xamarin.Models;
using Xamarin.Forms;

namespace xamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string chapters;
        private string volumes;
        private string episodes;
        public string Id { get; set; }

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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Chapters = item.Chapters;
                Volumes = item.Volumes;
                Episodes = item.Episodes;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
