using HGVHours.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HGVHours.Services
{
    public class HttpDataStore : IDataStore<Shift>
    {
        string endpoint = "https://hgvhours-default-rtdb.europe-west1.firebasedatabase.app/shifts";
        HttpClient httpClient;

        public HttpDataStore()
        {
            httpClient = new HttpClient();
        }

        public async Task<bool> AddItemAsync(Shift item)
        {
            string json = JsonConvert.SerializeObject(item);   //using Newtonsoft.Json

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{endpoint}.json", httpContent);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Shift item)
        {
            string json = JsonConvert.SerializeObject(item);   //using Newtonsoft.Json

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{endpoint}/{item.Id}.json", httpContent);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(true);
        }

        public async Task<Shift> GetItemAsync(string id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/{id}.json");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Shift shift = JsonConvert.DeserializeObject<Shift>(jsonResponse);
            return shift;
        }

        public async Task<IEnumerable<Shift>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await httpClient.GetAsync($"{endpoint}.json");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Dictionary<string, Shift> shiftsDict = JsonConvert.DeserializeObject<Dictionary<string, Shift>>(jsonResponse);

            List<Shift> shifts = shiftsDict.Select(x => {
               var item = x.Value;
               item.Id = x.Key;
               return item;
           }).ToList();

            return shifts;
        }
    }
}