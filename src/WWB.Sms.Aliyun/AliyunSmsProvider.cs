using System;
using System.Threading.Tasks;
using WWB.Sms.Core;
using WWB.Sms.Core.Error;
using WWB.Sms.Core.Helper;
using WWB.Sms.Core.Model;

namespace WWB.Sms.Aliyun
{
    public class AliyunSmsProvider : ISmsProvider
    {
        private readonly AlibabaCloud.SDK.Dysmsapi20170525.Client _client;
        private readonly IServiceProvider _serviceProvider;

        public AliyunSmsProvider(IServiceProvider serviceProvider, AliyunSmsConfig cfg)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = cfg.AccessKeyId,
                AccessKeySecret = cfg.AccessKeySecret,
                Endpoint = "dysmsapi.aliyuncs.com"
            };

            _client = new AlibabaCloud.SDK.Dysmsapi20170525.Client(config);

            _serviceProvider = serviceProvider;
        }

        public async Task<SendResult> Send(string phoneNumbers, string signName, string templateCode, string templateParam)
        {
            AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest sendSmsRequest = new AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest();
            sendSmsRequest.PhoneNumbers = phoneNumbers;
            sendSmsRequest.SignName = signName;
            sendSmsRequest.TemplateCode = templateCode;
            sendSmsRequest.TemplateParam = templateParam;

            var result = new SendResult();
            try
            {
                var smsResponse = await _client.SendSmsAsync(sendSmsRequest);
                if (smsResponse.Body.Code == "OK")
                {
                    result.IsSuccess = true;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Error = smsResponse.Body.Message;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Error = SmsErrorCode.PostError.GetDisplayContent();
            }

            return result;
        }
    }
}