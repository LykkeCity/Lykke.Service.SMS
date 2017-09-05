using System;
using System.Threading.Tasks;
using Lykke.AzureRepositories;
using Lykke.AzureRepositories.Extentions;
using Lykke.Core;
using Lykke.Job.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Services;
using Newtonsoft.Json;


namespace Lykke.Service.SMS.Services
{
    public class SmsService: ISmsService
    {
        private readonly ISmsServiceRepository _smsServiceRepository;
        private readonly ITraderRepository _traderRepository;

        public SmsService(ISmsServiceRepository smsServiceRepository, ITraderRepository traderRepository)
        {
            _smsServiceRepository = smsServiceRepository;
            _traderRepository = traderRepository;
        }
        public async Task<ISmsResponseModel> SendSms(ISmsModel sms)
        {
            //+375447890502
            bool useAlter = false;

            var settings = await _traderRepository.GetPropertiyByPhoneNumber(sms.PhoneNumber, "SmsSettings");
            if (!string.IsNullOrEmpty(settings))
            {
                try
                {
                    var setObj = JsonConvert.DeserializeObject<SmsSettings>(settings);
                    useAlter = setObj.UseAlternativeProvider;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }
                
            }

          
            var requestId = Guid.NewGuid();
            if (await _smsServiceRepository.SaveSmsRequestAsync(new SmsEntity
            {
                DateRow = DateTime.UtcNow.StorageString(),
                PhoneNumer = sms.PhoneNumber,
                PhoneOperator = (int)(useAlter ? PhoneOperator.Twilio : sms.PhoneOperator),
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
