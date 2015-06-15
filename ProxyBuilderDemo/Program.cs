using System;

namespace ProxyBuilderDemo
{
    class Program
    {
        static void Main()
        {
            ProxyBuilder proxyBuilder = new ProxyBuilder();
            Console.WriteLine(proxyBuilder.GetDefaultProxyAddress);
            Console.ReadKey();
        }
    }
}
