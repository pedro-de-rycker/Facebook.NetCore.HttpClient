using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Facebook.NetCore.HttpClient.ExtensionMethods
{
    /// <summary>
    /// Extensions methods for the IDictionary class.
    /// </summary>
    /// 

    public static class IDctionaryExtensionMethods
    {
        /// <summary>
        /// Changes a IDictionary object to a NameValueCollection
        /// </summary>
        /// <param name="dictionary">The source IDictionary</param>
        /// <returns>A NameValueCollection</returns>
        /// <example>dictionary.ToNameValueCollection()</example>
        /// 

        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dictionary)
        {
            var collection = new NameValueCollection();
            foreach(var pair in dictionary)
            {
                collection.Add(pair.Key, pair.Value);
            }

            return collection;
        }
    }
}
