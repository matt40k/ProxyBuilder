using System;
using System.Net;

public class ProxyBuilder
{
    public ProxyBuilder()
    {

    }

    public string Address { get; set; }
    public string Server { get; set; }
    public int Proxy { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public bool UseProxy
    {
        get
        {
            return false;
        }
    }

    public string GetProxyAddress
    {
        get
        {
            return null;
        }
    }

    //var uri = WebRequest.DefaultWebProxy.GetProxy(new Uri("http://www.google.com"));
}
