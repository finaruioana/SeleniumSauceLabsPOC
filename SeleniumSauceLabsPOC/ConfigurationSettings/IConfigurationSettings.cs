namespace SeleniumSauceLabsPOC.ConfigurationSettings
{
    public interface IConfigurationSettings
    {
        string TargetBrowser { get; }
        string TargetBrowserVersion { get; }
        string TargetPlatform{ get; }
    }
}