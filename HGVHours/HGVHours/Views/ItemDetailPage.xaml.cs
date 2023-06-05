using HGVHours.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HGVHours.Views
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