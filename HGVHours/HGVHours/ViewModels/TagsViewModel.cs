using HGVHours.Models;
using HGVHours.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HGVHours.ViewModels
{
    public class TagsViewModel : BaseViewModel
    {
        private Tag _selectedItem;

        public ObservableCollection<Tag> Tags { get; }
        public Command LoadTagsCommand { get; }
        public Command AddTagCommand { get; }
        public Command<Tag> ItemTapped { get; }

        public TagsViewModel()
        {
            Title = "Browse";
            Tags = new ObservableCollection<Tag>();
            LoadTagsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Tag>(OnItemSelected);
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
            SelectedItem = null;
        }

        public Tag SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewShiftPage));
        }

        async void OnItemSelected(Tag item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}