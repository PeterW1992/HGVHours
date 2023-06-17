using HGVHours.ViewModels;
using System;
using Xamarin.Forms;

namespace HGVHours.Controls
{
    public partial class TagsView : ContentView
    {
        TagsViewModel _viewModel;

        public TagsView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TagsViewModel();
            _viewModel.OnAppearing();
        }
    }
}