using Facebook.NetCore.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Facebook.NetCore.Client
{
    /// <summary>
    /// An HTTP client for Facebook graph API.
    /// </summary>
    /// 

    public class FacebookHttpClient : IFacebookHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// FacebookHttpClient constructor
        /// </summary>
        /// <param name="version">The version of the Facebook Graph API to target. Exemple : v6.0</param>
        /// <param name="accept">The expected return type of the Facebook Graph API. Default to application/json.</param>
        /// <exception cref="ArgumentException">Thrown when version format is not correct</exception>
        /// 

        public FacebookHttpClient(string version, string accept = "application/json")
        {
            var match = Regex.Match(version, @"v(\d+\.)(\d)");
            if(!match.Success)
            {
                throw new ArgumentException(
                    "Argument has incorrect format. Should be v[x].[x]. Exemple : v6.0",
                    nameof(version));
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(string.Format("https://graph.facebook.com/{0}/", version))
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
        }

        /// <summary>
        /// GET method to request the Facebook Graph API with raw return
        /// </summary>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>Unmodified request result</returns>
        /// 

        public async Task<HttpResponseMessage> GetRawAsync(
            string endpoint,
            IDictionary<string, string> args = null)
        {
            var response = await _httpClient.GetAsync(
                string.Format(
                    "{0}?{1}",
                    endpoint,
                    GetQueryString(args)
                    ),
                HttpCompletionOption.ResponseContentRead);
            return response;
        }

        /// <summary>
        /// GET method to request the Facebook Graph API with raw content return
        /// </summary>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>Raw content result as a string</returns>
        /// 

        public async Task<string> GetRawContentAsync(
            string endpoint,
            IDictionary<string, string> args = null)
        {
            var response = await GetRawAsync(endpoint, args);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }

        /// <summary>
        /// GET method to request the Facebook Graph API with raw content return
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>Raw content result as a casted object</returns>
        /// 

        public async Task<T> GetRawContentAsync<T>(
            string endpoint,
            IDictionary<string, string> args = null)
        {
            var response = await GetRawAsync(endpoint, args);

            if(response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }

            return default;
        }

        /// <summary>
        /// GET method to request the Facebook Graph API
        /// </summary>
        /// <typeparam name="T">Object type for the response content</typeparam>
        /// <param name="accessToken">Access token to pass along with the request</param>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns></returns>
        /// 

        public async Task<FacebookHttpResponseMessage<T>> GetContentAsync<T>(
            string accessToken,
            string endpoint,
            IDictionary<string, string> args = null)
        {
            args.Add("access_token", accessToken);

            var response = await GetRawAsync(endpoint, args);

            return await HandleResponse<T>(response);
        }

        /// <summary>
        /// POST method to request the Facebook Graph API
        /// </summary>
        /// <typeparam name="T">Object type for the response content</typeparam>
        /// <param name="accessToken">Access token to pass along with the request</param>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="payload">Body payload of the request</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns></returns>

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

            if(args is null)
            {
                return query;
            }

            foreach(KeyValuePair<string, string> pair in args)
            {
                query += string.Format("{0}={1}", pair.Key, pair.Value);
                if(!args.Last().Equals(pair))
                {
                    query += "&";
                }
            }

            return query;
        }

        private async Task<FacebookHttpResponseMessage<T>> HandleResponse<T>(HttpResponseMessage httpResponseMessage)
        {
            return new FacebookHttpResponseMessage<T>
            {
                IsSuccessfull = httpResponseMessage.IsSuccessStatusCode,
                HttpCode = httpResponseMessage.StatusCode,
                Content = httpResponseMessage.IsSuccessStatusCode ? JsonSerializer.Deserialize<T>(await httpResponseMessage.Content.ReadAsStringAsync()) : default
            };
        }
    }
}
