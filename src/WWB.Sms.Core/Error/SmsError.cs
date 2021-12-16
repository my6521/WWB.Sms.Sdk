namespace WWB.Sms.Core.Error
{
    public class SmsError
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public string ProviderMessage { get; set; }
    }
}