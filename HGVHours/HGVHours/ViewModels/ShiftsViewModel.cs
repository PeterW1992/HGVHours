using HGVHours.Models;
using HGVHours.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HGVHours.ViewModels
{
    public class ShiftsViewModel : BaseViewModel
    {
        private Shift _selectedItem;

        public ObservableCollection<Shift> Shifts { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Shift> ItemTapped { get; }

        public ShiftsViewModel()
        {
            Title = "Browse";
            Shifts = new ObservableCollection<Shift>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Shift>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Shifts.Clear();
                var shifts = await ShiftDataStore.GetItemsAsync(true);
                foreach (var item in shifts)
                {
                    Shifts.Add(item);
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

        public Shift SelectedItem
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

        async void OnItemSelected(Shift item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ShiftDetailPage)}?{nameof(ShiftDetailViewModel.ItemId)}={item.Id}");
        }
    }
}