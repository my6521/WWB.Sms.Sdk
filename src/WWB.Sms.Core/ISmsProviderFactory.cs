using WWB.Sms.Core.Config;

namespace WWB.Sms.Core
{
    public interface ISmsProviderFactory
    {
        ISmsProvider Create(BaseSmsConfig config);
    }
}