using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class EndpointAttribute : Attribute
    {
        public string Url { get; }

        public EndpointAttribute(string url)
        {
            Url = url;
        }
    }
}
