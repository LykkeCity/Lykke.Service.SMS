using System;
using System.Threading.Tasks;
using Lykke.AzureRepositories;
using Lykke.AzureRepositories.Extentions;
using Lykke.Core;
using Lykke.Job.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Services;


namespace Lykke.Service.SMS.Services
{
    public class SmsService: ISmsService
    {
        private readonly ISmsServiceRepository _smsServiceRepository;
        public SmsService(ISmsServiceRepository smsServiceRepository)
        {
            _smsServiceRepository = smsServiceRepository;
        }
        public async Task<ISmsResponseModel> SendSms(ISmsModel sms)
        {
            var requestId = Guid.NewGuid();
            if (await _smsServiceRepository.SaveSmsRequestAsync(new SmsEntity
            {
                DateRow = DateTime.UtcNow.StorageString(),
                PhoneNumer = sms.PhoneNumber,
                PhoneOperator = (int)sms.PhoneOperator,
                Message = sms.Message,
                RowId = requestId.ToString()
            }))
            {
                return new SmsResponseModel {SmsPostRequestStatus = SmsPostRequestStatus.Ok, SmsPostId = requestId};
            }
            return new SmsResponseModel { SmsPostRequestStatus = SmsPostRequestStatus.Error};
        }
    }
}
