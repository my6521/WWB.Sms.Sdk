using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using WWB.Sms.Core;

namespace WWB.Sms.Tests
{
    public class TestBase
    {
        protected ISmsProviderFactory SmsProviderFactory { get; set; }

        public TestBase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IHostingEnvironment, HostingEnvironment>();

            services.AddSms();

            var serviceProvider = services.BuildServiceProvider();

            SmsProviderFactory = serviceProvider.GetRequiredService<ISmsProviderFactory>();
        }
    }
}