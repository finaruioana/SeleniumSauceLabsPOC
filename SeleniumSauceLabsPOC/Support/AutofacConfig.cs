using Autofac;
using SeleniumSauceLabsPOC.ConfigurationSettings;

namespace SeleniumSauceLabsPOC.Support
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConfigurationSettings.ConfigurationSettings()).As<IConfigurationSettings>().SingleInstance();
        }
    }
}