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
            Port = GetProxyPort(_defaultProxy);
        } 
    }

    public IWebProxy Proxy
    {
        get
        {
            if (UseProxy)
            {
                WebProxy _webProxy;
                if (Port > 0)
                    _webProxy = new WebProxy(Address, Port);
                else
                    _webProxy = new WebProxy(Address);

                if (UseDefaultCredentials)
                    _webProxy.UseDefaultCredentials = UseDefaultCredentials;
                else
                {
                    _webProxy.UseDefaultCredentials = false;
                    _webProxy.Credentials = new NetworkCredential(Username, Password);
                }
                return _webProxy;
            }
            else
            {
                return null;
            }
        }
    }

    public bool UseProxy { get; set; }
    public string Address { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }

    private string _username;

    public string Username
    {
        get
        {
            return _username;
        }

        set 
        {
            UseDefaultCredentials = false;
            _username = value;
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
        return ProxyUri.Host;
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
