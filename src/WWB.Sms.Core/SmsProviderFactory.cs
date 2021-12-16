using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WWB.Sms.Core.Attributes;
using WWB.Sms.Core.Config;
using WWB.Sms.Core.Error;

namespace WWB.Sms.Core
{
    public class SmsProviderFactory : ISmsProviderFactory
    {
        public const string ASSEMBLY = "WWB.Sms.{0}";
        private readonly IServiceProvider _serviceProvider;
        private static Dictionary<SmsProviderTypes, Type> _providerTypeDic = new Dictionary<SmsProviderTypes, Type>();

        public SmsProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISmsProvider Create(BaseSmsConfig config)
        {
            var providerType = config.GetType().GetCustomAttribute<ConfigFlagAttribute>().ProviderType;
            if (!_providerTypeDic.ContainsKey(providerType))
            {
                var type = GetProviderType(providerType);
                _providerTypeDic.Add(providerType, type);
            }

            return (ISmsProvider)Activator.CreateInstance(_providerTypeDic[providerType], new object[] { _serviceProvider, config });
        }

        private Type GetProviderType(SmsProviderTypes providerType)
        {
            var assembly = Assembly.Load(string.Format(ASSEMBLY, providerType.ToString()));
            if (assembly == null)
                throw new SmsException(SmsErrorCode.ProviderNotFound.ToSmsError());

            var type = assembly.GetTypes().Where(type => typeof(ISmsProvider).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).FirstOrDefault();
            if (type == null)
                throw new SmsException(SmsErrorCode.ProviderNotFound.ToSmsError());

            return type;
        }
    }
}