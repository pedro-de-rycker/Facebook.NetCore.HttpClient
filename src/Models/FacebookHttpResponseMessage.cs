using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Facebook.NetCore.Client.Models
{
    /// <summary>
    /// Response from the Facebook Graph API
    /// </summary>
    /// <typeparam name="T">Response object type</typeparam>
    /// 

    public class FacebookHttpResponseMessage<T>
    {
        /// <summary>
        /// Boolean indicating if the request was successfull
        /// </summary>
        /// 

        public bool IsSuccessfull { get; set; }

        /// <summary>
        /// HttpCode returned by the Facebook Graph API
        /// </summary>
        /// 

        public HttpStatusCode HttpCode { get; set; }

        /// <summary>
        /// Content returned by the Facebook Graph API
        /// </summary>
        /// 

        public T Content { get; set; }
    }
}
