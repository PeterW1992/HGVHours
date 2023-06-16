using HGVHours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGVHours.Services
{
    public class MockDataStore : IDataStore<Shift>
    {
        readonly List<Shift> items;

        public MockDataStore()
        {
            DateTime dt = DateTime.Now;

            items = new List<Shift>()
            {
                new Shift { Id = Guid.NewGuid().ToString(),
                    StartDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 10, 28, 0),
                    EndDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 20, 15, 0),
                    Description="Sandycroft > Swindon"
                },
                new Shift { Id = Guid.NewGuid().ToString(),
                    StartDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 09, 5, 0).AddDays(-1),
                    EndDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 17, 50, 0).AddDays(-1),
                    Description="Watford Gap services > Derby > Marchington"
                },
                new Shift { Id = Guid.NewGuid().ToString(),
                    StartDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 9, 5, 0).AddDays(-2),
                    EndDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 22, 12, 0).AddDays(-2),
                    Description="Sandycroft > Sheppy"
                },
                new Shift { Id = Guid.NewGuid().ToString(),
                    StartDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 11, 35, 0).AddDays(-3),
                    EndDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 21, 15, 0).AddDays(-3),
                    Description="Sandycroft > Darlington"
                },
                new Shift { Id = Guid.NewGuid().ToString(),
                    StartDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 05, 5, 0).AddDays(-7),
                    EndDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 20, 0, 0).AddDays(-7),
                    Description="Sandycroft > Derby, Derby > Wakefield, Rochdale, Skelmesdale"
                },
                new Shift { Id = Guid.NewGuid().ToString(),
                    StartDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 7, 58, 0).AddDays(-8),
                    EndDateTime = new DateTime(dt.Year, dt.Month, dt.Day, 20, 30, 0).AddDays(-8),
                    Description="Pilgrims > Runcorn, Bolton, Neston"
                }};
        }

        public async Task<bool> AddItemAsync(Shift item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Shift item)
        {
            var oldItem = items.Where((Shift arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Shift arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Shift> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Shift>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}