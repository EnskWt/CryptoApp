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
        protected string GetEndpointUrl(object? parameters = null, [CallerMemberName] string methodName = "")
        {
            var methodInfo = GetType().GetMethod(methodName);
            var attribute = methodInfo?.GetCustomAttributes(typeof(EndpointAttribute), false).FirstOrDefault() as EndpointAttribute;

            if (attribute == null)
            {
                throw new InvalidOperationException($"No endpoint defined for method {methodName}");
            }

            var url = attribute.Url;
            if (parameters != null)
            {
                foreach (var prop in parameters.GetType().GetProperties())
                {
                    url = url.Replace($"{{{prop.Name}}}", prop.GetValue(parameters)?.ToString());
                }
            }

            return url;
        }
    }
}
