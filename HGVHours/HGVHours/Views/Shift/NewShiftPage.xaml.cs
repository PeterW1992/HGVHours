using HGVHours.Models;
using HGVHours.ViewModels;
using Xamarin.Forms;

namespace HGVHours.Views
{
    public partial class NewShiftPage : ContentPage
    {
        public Shift Shift { get; set; }

        public NewShiftPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

    }
}