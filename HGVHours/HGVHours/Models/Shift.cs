using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

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
        public double ShiftLength { get => EndDateTime == null ? 0 : Math.Round((EndDateTime - StartDateTime).TotalHours, 2); }

        public List<Tag> Tags { get; set; }

    }
}