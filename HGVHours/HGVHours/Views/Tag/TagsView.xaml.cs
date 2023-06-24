using HGVHours.Models;
using HGVHours.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace HGVHours.Controls
{
    public partial class TagsView : ContentView
    {
        TagsViewModel _viewModel;


        public static readonly BindableProperty SelectedTagsProperty = BindableProperty.Create(
            "SelectedTags",
            typeof(List<Tag>),
            typeof(List<Tag>),
            new List<Tag>(),
            BindingMode.TwoWay,
            propertyChanged: (bindable, oldValue, newValue) => {
                Console.WriteLine($"Property change count: {((List<Tag>)newValue).Count}");
            }
        );

        public List<Tag> SelectedTags
        {
            get { return (List<Tag>)GetValue(SelectedTagsProperty); }
            set { SetValue(SelectedTagsProperty, value); }
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            List<Tag> local = new List<Tag>();

            SelectedTags.Clear();

            foreach (var obj in currentSelectedItems)
            {
                local.Add((Tag)obj);
            }
            SelectedTags = local;
        }

        public TagsView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TagsViewModel();
            _viewModel.OnAppearing();
        }
    }
}