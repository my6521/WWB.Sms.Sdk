using Microsoft.Extensions.DependencyInjection;
using WWB.Sms.Core.Error;
using WWB.Sms.Core.Helper;

namespace WWB.Sms.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddSms(this IServiceCollection services)
        {
            services.AddSingleton<ISmsProviderFactory, SmsProviderFactory>();

            return services;
        }

        /// <summary>
        /// 根据错误类型返回错误异常
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static SmsError ToSmsError(this SmsErrorCode code) => new SmsError()
        {
            Code = (int)code,
            Message = code.GetDisplayContent()
        };
    }
}