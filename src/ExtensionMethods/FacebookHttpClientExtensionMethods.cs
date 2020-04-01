using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Facebook.NetCore.HttpClient.ExtensionMethods
{
    /// <summary>
    /// Extensions methods for the FacebookHttpClient class.
    /// </summary>
    /// 

    public static class FacebookHttpClientExtensionMethods
    {
        /// <summary>
        /// Send a Facebook format GET request to the specified Uri with an HTTP completion option and a
        ///  cancellation token as an asynchronous operation.
        /// </summary>
        /// <param name="httpClient">The FacebookHttpClient.</param>
        /// <param name="endpoint">The endpoint request.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="args">The dictionary of arguments to pass.</param>
        /// <param name="options">An HTTP completion option value that indicates when the operation should be considered completed.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">The endpoint is null.</exception>
        /// 

        public static async Task GetAsync(
            this FacebookHttpClient httpClient,
            string endpoint,
            string accessToken,
            IDictionary<string, string> args = null,
            System.Net.Http.HttpCompletionOption options = default,
            System.Threading.CancellationToken cancellationToken = default)
        {
            if (args is null) { args = new Dictionary<string, string>(); }
            args.Add("access_token", accessToken);

            var result = await httpClient.GetAsync(BuildEndpoint(endpoint, args), options, cancellationToken);
        }

        /// <summary>
        /// Send a POST request with a cancellation token as an asynchronous operation.
        /// </summary>
        /// <param name="httpClient">The FacebookHttpClient.</param>
        /// <param name="content">The HttpContent to pass in the request.</param>
        /// <param name="endpoint">The endpoint request.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="args">The dictionary of arguments to pass.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="System.ArgumentNullException">The endpoint is null.</exception>
        /// 

        public static async Task PostAsync(
            this FacebookHttpClient httpClient,
            string endpoint,
            HttpContent content,
            string accessToken,
            IDictionary<string, string> args = null,
            System.Threading.CancellationToken cancellationToken = default)
        {
            if (args is null) { args = new Dictionary<string, string>(); }
            args.Add("access_token", accessToken);

            var result = await httpClient.PostAsync(BuildEndpoint(endpoint, args), content, cancellationToken);
        }

        private static string BuildEndpoint(string endpoint, IDictionary<string, string> args)
        {
            UriBuilder builder = new UriBuilder();
            var query = HttpUtility.ParseQueryString(string.Empty);
            query.Add(args.ToNameValueCollection());
            builder.Path = endpoint;
            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
