using HGVHours.ViewModels;
using Xamarin.Forms;

namespace HGVHours.Views
{
    public partial class ShiftDetailPage : ContentPage
    {
        public ShiftDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}