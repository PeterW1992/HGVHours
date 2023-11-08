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
            nameof(SelectedTags),
            typeof(ObservableCollection<Tag>),
            typeof(TagsView),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is TagsView _this)
                {
                    _this.SelectedTags = (ObservableCollection<Tag>) newValue;
                }
                Console.WriteLine($"Property change count: {((ObservableCollection<Tag>)newValue).Count}");
            }
        );

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(TagsView),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is TagsView _this)
                {
                    _this.Text = (string)newValue;
                }
                Console.WriteLine($"Property colour change count: {((Color)newValue).R}");
            }
        );

        public TagsView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TagsViewModel();
            _viewModel.OnAppearing();
        }

        public ObservableCollection<Tag> SelectedTags
        {
            get { return (ObservableCollection<Tag>)GetValue(SelectedTagsProperty); }
            set { SetValue(SelectedTagsProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            ObservableCollection<Tag> local = new ObservableCollection<Tag>();

            foreach (var obj in currentSelectedItems)
            {
                local.Add((Tag)obj);
            }
            SelectedTags = local;
        }
    }
}