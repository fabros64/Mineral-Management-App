using Mineral_Management.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Mineral_Management.Services
{
    public class MongoDataStore : IDataStore<JsonProduct>
    {
        HttpClient client;
        IEnumerable<JsonProduct> items;

        public MongoDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            items = new List<JsonProduct>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<JsonProduct>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<JsonProduct>>(json));
            }

            return items;
        }

        public async Task<JsonProduct> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"product/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<JsonProduct>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(JsonProduct item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"product", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(JsonProduct item)
        {
            if (item == null || item.ProductId == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PutAsync($"product/{item.ProductId}", 
                new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"product/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
