using Facebook.NetCore.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.NetCore.Client
{
    public interface IFacebookClient
    {
        Task<FacebookHttpResponseMessage<T>> GetAsync<T>(
            string accessToken,
            string endpoint,
            IDictionary<string, string> args = null);

        Task<FacebookHttpResponseMessage<T>> PostAsync<T>(
            string accessToken,
            string endpoint,
            dynamic payload,
            IDictionary<string, string> args = null);
    }
}
