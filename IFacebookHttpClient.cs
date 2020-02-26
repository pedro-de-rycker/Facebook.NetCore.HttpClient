using Facebook.NetCore.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.NetCore.Client
{
    /// <summary>
    /// Interface for the Facebook HTTP client
    /// </summary>
    /// 

    public interface IFacebookHttpClient
    {
        /// <summary>
        /// GET method to request the Facebook Graph API with raw return
        /// </summary>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>Unmodified request result</returns>
        /// 

        Task<HttpResponseMessage> GetRawAsync(
            string endpoint,
            IDictionary<string, string> args = null);

        /// <summary>
        /// GET method to request the Facebook Graph API with raw content return
        /// </summary>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>Raw content result as a string</returns>
        /// 

        Task<string> GetRawContentAsync(
            string endpoint,
            IDictionary<string, string> args = null);

        /// <summary>
        /// GET method to request the Facebook Graph API with raw content return
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>Raw content result as a casted object</returns>
        /// 

        Task<T> GetRawContentAsync<T>(
            string endpoint,
            IDictionary<string, string> args = null);

        /// <summary>
        /// GET method to request the Facebook Graph API
        /// </summary>
        /// <typeparam name="T">Object type for the response content</typeparam>
        /// <param name="accessToken">Access token to pass along with the request</param>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>A typed FacebookHttpResponseMessage object</returns>
        /// 

        Task<FacebookHttpResponseMessage<T>> GetContentAsync<T>(
            string accessToken,
            string endpoint,
            IDictionary<string, string> args = null);

        /// <summary>
        /// POST method to request the Facebook Graph API
        /// </summary>
        /// <typeparam name="T">Object type for the response content</typeparam>
        /// <param name="accessToken">Access token to pass along with the request</param>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="payload">Body payload of the request</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns>A typed FacebookHttpResponseMessage object</returns>

        Task<FacebookHttpResponseMessage<T>> PostAsync<T>(
            string accessToken,
            string endpoint,
            dynamic payload,
            IDictionary<string, string> args = null);
    }
}
