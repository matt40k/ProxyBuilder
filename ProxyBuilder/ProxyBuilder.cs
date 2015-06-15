using System;
using System.Net;

public class ProxyBuilder
{
    public ProxyBuilder()
    {
        UseProxy = false;
        UseDefaultCredentials = false;
        Uri _defaultProxy = GetDefaultProxyAddress;
        if (_defaultProxy != null)
        {
            Address = GetProxyAddress(_defaultProxy);
            Proxy = GetProxyPort(_defaultProxy);
        } 
    }

    public bool UseProxy { get; set; }
    public string Address { get; set; }
    public string Server { get; set; }
    public int Proxy { get; set; }
    public string Username
    {
        get
        {
            return Username;
        }

        set
        {
            UseDefaultCredentials = false;
            Username = value;
        }
    }
    public string Password { get; set; }
    public bool UseDefaultCredentials { get; set; }

    public Uri GetDefaultProxyAddress
    {
        get
        {
            Uri address = new Uri("http://www.microsoft.com/");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            IWebProxy myProxy = request.Proxy;
            Uri proxyUri = myProxy.GetProxy(address);
            if (address.Equals(proxyUri))
            {
                UseDefaultCredentials = false;
                UseProxy = false;
                return null;
            }
            else
            {
                UseDefaultCredentials = true;
                UseProxy = true;
                return proxyUri;
            }
        }
    }

    public string GetProxyAddress(Uri ProxyUri)
    {
        return ProxyUri.AbsoluteUri;
    }

    public int GetProxyPort(Uri ProxyUri)
    {
        return ProxyUri.Port;
    }

    public Uri GetProxyUri(string ProxyAddress, int ProxyPort)
    {
        return new Uri(ProxyAddress + ':' + ProxyPort.ToString() + '/');
    }
}
