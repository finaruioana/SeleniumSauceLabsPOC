namespace SeleniumSauceLabsPOC.ConfigurationSettings
{
    public interface IConfigurationSettings
    {
        string TargetBrowser { get; }
        string TargetOs { get; }
        string TargetDevice { get; }
    }
}