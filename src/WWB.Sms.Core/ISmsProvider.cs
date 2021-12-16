using System.Threading.Tasks;
using WWB.Sms.Core.Model;

namespace WWB.Sms.Core
{
    public interface ISmsProvider
    {
        Task<SendResult> Send(string phoneNumbers, string signName, string templateCode, string templateParam);
    }
}