using System;

namespace WWB.Sms.Core.Error
{
    public class SmsException : Exception
    {
        public SmsException(SmsError error) : base(error.Message)
        {
            ErrorCode = error.Code;
        }

        public SmsException(SmsError error, Exception ex) : base(error.Message, ex)
        {
            ErrorCode = error.Code;
            ProviderMessage = ex?.Message;
        }

        public int ErrorCode { get; private set; }

        public string ProviderMessage { get; set; }
    }
}