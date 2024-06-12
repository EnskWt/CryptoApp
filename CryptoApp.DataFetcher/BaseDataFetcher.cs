using CryptoApp.DataFetcher.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.DataFetcher
{
    public abstract class BaseDataFetcher
    {
        protected string GetEndpointUrl([CallerMemberName] string methodName = "")
        {
            var methodInfo = GetType().GetMethod(methodName);
            var attribute = methodInfo?.GetCustomAttributes(typeof(EndpointAttribute), false).FirstOrDefault() as EndpointAttribute;

            if (attribute == null)
            {
                throw new InvalidOperationException($"No endpoint defined for method {methodName}");
            }

            return attribute.Url;
        }
    }
}
