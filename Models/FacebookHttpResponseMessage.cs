using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Facebook.NetCore.Client.Models
{
    public class FacebookHttpResponseMessage<T>
    {
        public bool IsSuccessfull { get; set; }

        public HttpStatusCode HttpCode { get; set; }

        public T Content { get; set; }
    }
}
