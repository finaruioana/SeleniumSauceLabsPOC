using System.Collections.Specialized;

namespace SeleniumSauceLabsPOC.ConfigurationSettings
{
    public interface IConfigurationSettings
    {
        NameValueCollection Capabilities { get; }
        string Username { get; }
        string Key { get; }
        string Server { get; }
    }
}