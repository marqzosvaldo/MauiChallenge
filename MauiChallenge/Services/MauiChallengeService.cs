using MauiChallenge.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiChallenge.Services {
    public class MauiChallengeService {

        static readonly string Url = "http://52.226.224.79:3000/items";
     

        HttpClient _httpClient;


        public MauiChallengeService(){
                _httpClient = new HttpClient();
        }


        public async Task<IEnumerable<Item>> GetItems() {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, Url);

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            if (response.IsSuccessStatusCode) {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);


                var items = JsonSerializer.Deserialize<IEnumerable<Item>>(response.Content.ReadAsStringAsync().Result);

                return items;
            }

            return new List<Item>();

        }

        public async Task<Item> AddItem(Item item) {

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, Url);

            message.Content = JsonContent.Create<Item>(item);

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            if (response.IsSuccessStatusCode) {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);


                var devicer = JsonSerializer.Deserialize<Item>(response.Content.ReadAsStringAsync().Result);

                return devicer;
            }

            return null;
        }

        public async Task<bool> DeleteItem(int itemId) {

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, $"{Url}/{itemId}");

            

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            if (response.IsSuccessStatusCode) {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);


                //var devicer = JsonSerializer.Deserialize<Item>(response.Content.ReadAsStringAsync().Result);

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateItem(Item item) {

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, $"{Url}/{item.id}");

            var putItem = new Item() {
                name = item.name
            };
            message.Content = JsonContent.Create<Item>(putItem);

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            if (response.IsSuccessStatusCode) {
                Debug.WriteLine(response.Content.ReadAsStringAsync().Result);


                //var devicer = JsonSerializer.Deserialize<Item>(response.Content.ReadAsStringAsync().Result);

                return true;
            }

            return false;
        }

    }
}
