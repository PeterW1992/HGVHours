using HGVHours.ViewModels;
using System;
using Xamarin.Forms;

namespace HGVHours.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            Console.WriteLine($"Items in ViewModel: {_viewModel.Items.Count}");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            Console.WriteLine($"Items in ViewModel: {_viewModel.Items.Count}");
        }
    }
}