using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace XamarinFormsSandbox.WorkingWithData
{
    public class RestClientService
    {
        private readonly string BaseUrl = "https://jsonplaceholder.typicode.com";

        private HttpClient client;

        public RestClientService()
        {
            client = new HttpClient() { BaseAddress = new Uri(BaseUrl) };
        }

        public async Task<string> GetAsync(string route)
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                HttpResponseMessage responseMessage = await client.GetAsync(route);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<T> GetAsync<T>(string route)
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                HttpResponseMessage responseMessage = await client.GetAsync(route);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
                }
            }

            return default;
        }

        public async Task<string> PostAsync(string route, object body)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PostAsync(route, stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<string> PatchAsync(string route, object body)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var method = new HttpMethod("PATCH");

                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(method, route)
                {
                    Content = stringContent
                };

                HttpResponseMessage responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<string> DeleteAsync(string route)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync(route);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsStringAsync();
                }
            }

            return "";
        }
    }
}
