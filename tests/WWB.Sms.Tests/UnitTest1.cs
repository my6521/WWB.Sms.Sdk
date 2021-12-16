using System.Threading.Tasks;
using WWB.Sms.Aliyun;
using Xunit;

namespace WWB.Sms.Tests
{
    public class UnitTest1 : TestBase
    {
        [Fact(DisplayName = "�����Ʒ��Ͷ��Ų���")]
        public async Task Test1()
        {
            var config = new AliyunSmsConfig
            {
                AccessKeyId = "",
                AccessKeySecret = ""
            };
            var provider = SmsProviderFactory.Create(config);
            var result = await provider.Send("18981713541", "�����Ƽ�", "SMS_197210271", "{\"code\":\"1234\"}");

            Assert.True(result.IsSuccess);
        }
    }
}