using HGVHours.Models;
using HGVHours.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HGVHours.ViewModels
{
    public class TagsViewModel : BaseViewModel
    {
        public ObservableCollection<Tag> Tags { get; set; }

        public ObservableCollection<Tag> SelectedTags { get; set; }

        public Command LoadTagsCommand { get; }
        public Command AddTagCommand { get; }

        public TagsViewModel()
        {
            Title = "Browse";
            Tags = new ObservableCollection<Tag>();
            LoadTagsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddTagCommand = new Command(OnAddItem);
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Tags.Clear();
                var tags = await TagDataStore.GetItemsAsync(true);
                foreach (var item in tags)
                {
                    Tags.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTags = new ObservableCollection<Tag>();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewShiftPage));
        }
    }
}