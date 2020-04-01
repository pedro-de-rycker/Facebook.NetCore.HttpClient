using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Facebook.NetCore.HttpClient
{
    /// <summary>
    /// An extended HttpClient to use the Facebook graph API.
    /// </summary>
    /// 

    public class FacebookHttpClient : System.Net.Http.HttpClient
    {
        /// <summary>
        /// An extended HttpClient for the Facebook graph API
        /// </summary>
        /// <param name="version">The Facebook graph API version to reach</param>
        /// <example>new FacebookHttpClient("v6.0")</example>
        /// <exception cref="ArgumentException">Thrown if the Facebook graph API <paramref name="version"/> is not in the proper format.</exception>
        /// 

        public FacebookHttpClient(string version)
        {
            var match = Regex.Match(version, @"v(\d+\.)(\d)");
            if (!match.Success)
            {
                throw new ArgumentException(
                    "Argument has incorrect format. Should be v[x].[x]. Exemple : v6.0",
                    nameof(version));
            }

            BaseAddress = new Uri(string.Format("https://graph.facebook.com/{0}/", version));
        }
    }
}
