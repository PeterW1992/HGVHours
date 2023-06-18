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

        IEnumerable<Object> selectedTags;

        public IEnumerable<Object> SelectedTags
        {
            get
            {
                return selectedTags;
            }
            set
            {
                if (selectedTags != value)
                {
                    selectedTags = value;
                }
            }
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            SelectedTags = currentSelectedItems;
            var selectedTags = ToList(SelectedTags);
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(selectedTags) ? "[none]" : selectedTags;
        }

        static string ToList(IEnumerable<object> items)
        {
            if (items == null)
            {
                return string.Empty;
            }

            return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((Tag)obj).Name);
        }

        public TagsView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TagsViewModel();
            _viewModel.OnAppearing();
        }
    }
}