using System;
using System.Collections.Generic;
using System.ComponentModel;
using xamarin.Models;
using xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}