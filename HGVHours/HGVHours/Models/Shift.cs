using System;

namespace HGVHours.Models
{
    public class Shift
    {
        public string Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StartDate { get => StartDateTime.ToString("dd/MM/yyyy"); }
        public double ShiftLength { get => EndDateTime == null ? 0 : (EndDateTime - StartDateTime).TotalHours; }
        public string Description { get; set; }
    }
}