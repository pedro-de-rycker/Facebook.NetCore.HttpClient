using Facebook.NetCore.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Facebook.NetCore.Client
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://graph.facebook.com/v6.0/")
        };

        public async Task<FacebookHttpResponseMessage<T>> GetAsync<T>(
            string accessToken,
            string endpoint,
            IDictionary<string, string> args = null)
        {
            var response = await _httpClient.GetAsync(
                string.Format(
                    "{0}?access_token={1}&{2}",
                    endpoint,
                    accessToken,
                    GetQueryString(args)
                    ),
                HttpCompletionOption.ResponseContentRead);

            return await HandleResponse<T>(response);
        }

        public async Task<FacebookHttpResponseMessage<T>> PostAsync<T>(
            string accessToken,
            string endpoint,
            dynamic payload,
            IDictionary<string, string> args = null)
        {
            var response = await _httpClient.PostAsync(
                string.Format(
                    "{0}?access_token={1}&{2}",
                    endpoint,
                    accessToken,
                    GetQueryString(args)
                    ),
                JsonSerializer.Serialize(payload));

            return await HandleResponse<T>(response);
        }

        private string GetQueryString(IDictionary<string, string> args)
        {
            string query = string.Empty;
            foreach(KeyValuePair<string, string> pair in args)
            {
                query += string.Format("{0}={1}", pair.Key, pair.Value);
            }

            return query;
        }

        private async Task<FacebookHttpResponseMessage<T>> HandleResponse<T>(HttpResponseMessage httpResponseMessage)
        {
            return new FacebookHttpResponseMessage<T>
            {
                IsSuccessfull = httpResponseMessage.IsSuccessStatusCode,
                HttpCode = httpResponseMessage.StatusCode,
                Content = JsonSerializer.Deserialize<T>(await httpResponseMessage.Content.ReadAsStringAsync())
            };
        }
    }
}
