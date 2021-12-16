using WWB.Sms.Core.Attributes;
using WWB.Sms.Core.Config;

namespace WWB.Sms.Aliyun
{
    [ConfigFlag(Core.SmsProviderTypes.Aliyun)]
    public class AliyunSmsConfig : BaseSmsConfig
    {
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
    }
}