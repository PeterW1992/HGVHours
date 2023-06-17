using HGVHours.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HGVHours.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShiftsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ShiftsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}