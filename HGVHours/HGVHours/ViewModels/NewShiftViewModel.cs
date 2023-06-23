using HGVHours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace HGVHours.ViewModels
{
    public class NewShiftViewModel : BaseViewModel
    {
        private DateTime startDate = DateTime.Now;
        private TimeSpan startTime;
        private DateTime endDate;
        private TimeSpan endTime;
        private IEnumerable<Tag> selectedTags;

        public IEnumerable<Tag> SelectedTags
        {
            get => selectedTags;
            set
            {
                SetProperty(ref selectedTags, value);
                OnPropertyChanged(nameof(selectedTags));
            }
        }

        public string SelectedTagsStr
        {
            get => SelectedTagsToStr();
        }

        private string SelectedTagsToStr()
        {
            if (this.SelectedTags == null)
            {
                return "Selected tag count NewShiftViewModel: null";
            }
            return $"Selected tag count NewShiftViewModel: {SelectedTags.ToList().Count}";
        }

        private string description;

        public NewShiftViewModel()
        {
            SelectedTags = new List<Tag>();
            StartTime = DateTime.Now - DateTime.Now.Date;
            UpdateDataCommand = new Command(DisplayData);
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
            get
            {
                if (StartTime > EndTime)
                {
                    return EndTime.Add(new TimeSpan(1, 0, 0, 0) - StartTime).TotalHours;
                }
                return (EndTime - StartTime).TotalHours;
            }
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command UpdateDataCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void DisplayData()
        {
            Console.WriteLine($"Comeon bruh: {SelectedTags.ToList().Count}");
            SelectedTags = SelectedTags;
        }

        private async void OnSave()
        {
            Convert.ToInt32(StartTime.TotalHours);
            Shift newItem = new Shift()
            {
                StartDateTime = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, (int)StartTime.TotalHours, (int)StartTime.TotalSeconds % 60, 0),
                EndDateTime = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, (int)EndTime.TotalHours, (int)EndTime.TotalSeconds % 60, 0),
                Description = Description
            };

            await ShiftDataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
