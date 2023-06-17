using HGVHours.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HGVHours.Services
{
    public class TagHttpDataStore : IDataStore<Tag>
    {
        string endpoint = "https://hgvhours-default-rtdb.europe-west1.firebasedatabase.app/tags";
        HttpClient httpClient;

        public TagHttpDataStore()
        {
            httpClient = new HttpClient();
        }

        public async Task<bool> AddItemAsync(Tag tag)
        {
            string json = JsonConvert.SerializeObject(tag);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{endpoint}.json", httpContent);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Tag tag)
        {
            string json = JsonConvert.SerializeObject(tag);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{endpoint}/{tag.Id}.json", httpContent);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(true);
        }

        public async Task<Tag> GetItemAsync(string id)
        {
            var response = await httpClient.GetAsync($"{endpoint}/{id}.json");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Tag tag = JsonConvert.DeserializeObject<Tag>(jsonResponse);
            return tag;
        }

        public async Task<IEnumerable<Tag>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await httpClient.GetAsync($"{endpoint}.json");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Dictionary<string, Tag> tagsDict = JsonConvert.DeserializeObject<Dictionary<string, Tag>>(jsonResponse);

            List<Tag> tags = tagsDict.Select(x => {
               var item = x.Value;
               item.Id = x.Key;
               return item;
           }).ToList();

            return tags;
        }
    }
}