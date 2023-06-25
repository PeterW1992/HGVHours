using HGVHours.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HGVHours.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShiftsPage : ContentPage
    {
        ShiftsViewModel _viewModel;

        public ShiftsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ShiftsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}