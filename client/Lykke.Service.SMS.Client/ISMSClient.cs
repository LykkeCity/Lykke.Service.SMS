
using System.Threading.Tasks;
using SmsRequestModel = Lykke.Service.SMS.Client.AutorestClient.Models.SmsRequestModel;

namespace Lykke.Service.SMS.Client
{
    public interface ISMSClient
    {
        Task<SmsResponseModel> SendSms(SmsRequestModel sms);
    }
}