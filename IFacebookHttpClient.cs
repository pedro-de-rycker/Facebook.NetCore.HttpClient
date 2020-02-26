using Facebook.NetCore.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.NetCore.Client
{
    public interface IFacebookClient
    {
        /// <summary>
        /// GET method to request the Facebook Graph API
        /// </summary>
        /// <typeparam name="T">Object type for the response content</typeparam>
        /// <param name="accessToken">Access token to pass along with the request</param>
        /// <param name="endpoint">The endpoint the request should reach</param>
        /// <param name="args">Dictionary of arguments to query with</param>
        /// <returns></returns>
        /// 

        Task<FacebookHttpResponseMessage<T>> GetAsync<T>(
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
        /// <returns></returns>

        Task<FacebookHttpResponseMessage<T>> PostAsync<T>(
            string accessToken,
            string endpoint,
            dynamic payload,
            IDictionary<string, string> args = null);
    }
}
