using System;

namespace WWB.Sms.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigFlagAttribute : Attribute
    {
        public SmsProviderTypes ProviderType { get; private set; }

        public ConfigFlagAttribute(SmsProviderTypes providerType)
        {
            ProviderType = providerType;
        }
    }
}