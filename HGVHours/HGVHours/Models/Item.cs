using System;

namespace HGVHours.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string StartDate { get => StartDateTime.ToString("dd/MM/yyyy"); }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double ShiftLength { get => (EndDateTime - StartDateTime).TotalHours; }
        public string Description { get; set; }
    }
}