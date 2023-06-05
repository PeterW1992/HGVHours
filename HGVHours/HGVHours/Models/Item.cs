using System;

namespace HGVHours.Models
{
    public class Item
    {
        public string Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
    }
}