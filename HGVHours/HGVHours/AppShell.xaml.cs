using HGVHours.ViewModels;
using HGVHours.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HGVHours
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ShiftDetailPage), typeof(ShiftDetailPage));
            Routing.RegisterRoute(nameof(NewShiftPage), typeof(NewShiftPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
