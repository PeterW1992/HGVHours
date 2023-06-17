using HGVHours.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HGVHours.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ShiftDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string description;
        private DateTime startDateTime;
        private TimeSpan endTime;
        private DateTime endDate;

        public Command UpdateCommand { get; }

        public ShiftDetailViewModel()
        {
            UpdateCommand = new Command(OnUpdate, ValidateUpdate);
        }

        private bool ValidateUpdate()
        {
            if (endTime == null)
                return false;

            return true;
        }

        private async void OnUpdate()
        {
            Shift existingShift = new Shift()
            {
                Id = itemId,
                StartDateTime = startDateTime,
                EndDateTime = new DateTime(endDate.Year,endDate.Month,endDate.Day, EndTime.Hours, EndTime.Minutes, 0),
                Description = description
            };

            await ShiftDataStore.UpdateItemAsync(existingShift);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public string Id { get; set; }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public DateTime StartDateTime
        {
            get => startDateTime;
            set => SetProperty(ref startDateTime, value);
        }

        public TimeSpan EndTime
        {
            get => endTime;
            set => SetProperty(ref endTime, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await ShiftDataStore.GetItemAsync(itemId);
                Id = item.Id;
                Description = item.Description;
                StartDateTime = item.StartDateTime;
                EndTime = new TimeSpan(item.EndDateTime.TimeOfDay.Ticks);
                endDate = item.EndDateTime;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
