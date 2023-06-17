using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace HGVHours.Models
{
    public class Shift
    {
        public string Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public string StartDate { get => StartDateTime.ToString("dd/MM/yyyy"); }

        [JsonIgnore]
        public double ShiftLength { get => EndDateTime == null ? 0 : (EndDateTime - StartDateTime).TotalHours; }
    }
}