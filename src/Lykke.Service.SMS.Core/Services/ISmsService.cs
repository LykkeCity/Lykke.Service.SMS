using System.Threading.Tasks;
using Lykke.Job.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Domain;

namespace Lykke.Service.SMS.Core.Services
{
    public interface ISmsService
    {
        Task<ISmsResponseModel> SendSms(ISmsModel sms);
    }
}
