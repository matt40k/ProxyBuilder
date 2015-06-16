using System;
using System.Net;

namespace ProxyBuilderDemo
{
    class Program
    {
        static void Main()
        {
            ProxyBuilder proxyBuilder = new ProxyBuilder();
            Console.WriteLine(proxyBuilder.GetDefaultProxyAddress);
            string url = "http://www.microsoft.com/";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = proxyBuilder.Proxy;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusCode);
            Console.ReadKey();
        }
    }
}
