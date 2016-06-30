using System;

using FluentAssertions.Execution;
using FluentAssertions.Formatting;
using FluentAssertions.Xml;

using Microsoft.Framework.Configuration;

namespace FluentAssertions.Common
{
    public class ProvidePlatformServices : IProvidePlatformServices
    {
        public Action<string> Throw
        {
            get { return TestFrameworkProvider.Throw; }
        }

        public IConfigurationStore ConfigurationStore
        {
            get
            {
                var builder = new ConfigurationBuilder();
                return new AppSettingsConfigurationStore(builder.Build());
            }
        }

        public IReflector Reflector
        {
            get { return new DefaultReflector(); }
        }

        public IValueFormatter[] Formatters
        {
            get
            {
                return new IValueFormatter[]
                {
                    new AggregateExceptionValueFormatter(),
                    new XDocumentValueFormatter(),
                    new XElementValueFormatter(),
                    new XAttributeValueFormatter(),
                    new XmlNodeFormatter()
                };
            }
        }
    }
}