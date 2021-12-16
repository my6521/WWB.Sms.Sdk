using System.Threading.Tasks;
using WWB.Sms.Aliyun;
using Xunit;

namespace WWB.Sms.Tests
{
    public class UnitTest1 : TestBase
    {
        [Fact(DisplayName = "阿里云发送短信测试")]
        public async Task Test1()
        {
            var config = new AliyunSmsConfig
            {
                AccessKeyId = "",
                AccessKeySecret = ""
            };
            var provider = SmsProviderFactory.Create(config);
            var result = await provider.Send("18981713541", "蓝宁科技", "SMS_197210271", "{\"code\":\"1234\"}");

            Assert.True(result.IsSuccess);
        }
    }
}