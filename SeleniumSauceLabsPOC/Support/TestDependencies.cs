using System;
using System.Linq;
using Autofac;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Support
{
    public class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());

            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            return builder;

        }
    }
}