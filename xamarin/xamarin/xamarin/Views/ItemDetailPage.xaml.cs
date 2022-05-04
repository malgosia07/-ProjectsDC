using System.ComponentModel;
using xamarin.ViewModels;
using Xamarin.Forms;

namespace xamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}