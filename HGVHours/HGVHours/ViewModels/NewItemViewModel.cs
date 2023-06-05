using HGVHours.Models;
using System;
using Xamarin.Forms;

namespace HGVHours.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private DateTime startDate = DateTime.Now;
        private TimeSpan startTime;
        private DateTime endDate;
        private TimeSpan endTime;

        private string description;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            if (startDate == null)
                return false;

            return true;
        }

        public DateTime StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }
        public TimeSpan StartTime
        {
            get => startTime;
            set => SetProperty(ref startTime, value);
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                SetProperty(ref endDate, value);
                OnPropertyChanged(nameof(HoursElapsed));
            }
        }

        public TimeSpan EndTime
        {
            get => endTime;
            set
            {
                SetProperty(ref endTime, value);
                OnPropertyChanged(nameof(HoursElapsed));
            }
        }

        public double HoursElapsed
        {
            get => (EndTime - StartTime).TotalHours;
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ;
            Convert.ToInt32(StartTime.TotalHours);
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                StartDateTime = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, (int)StartTime.TotalHours, (int)StartTime.TotalSeconds % 60, 0),
                EndDateTime = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, (int)EndTime.TotalHours, (int)EndTime.TotalSeconds % 60, 0),
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
