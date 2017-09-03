using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lykke.Core;
using Lykke.Job.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Services;
using Lykke.Service.SMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.SMS.Controllers
{
    [Route("api/[controller]")]
    public class SmsComtroller : Controller
    {
        private readonly ISmsService _smsService;

        public SmsComtroller(ISmsService smsService)
        {
            _smsService = smsService;
        }
       [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody]SmsRequestModel reuqest)
        {
            if (string.IsNullOrEmpty(reuqest.PhoneNumber))
            {
                return Json(new SmsResponseModel {SmsPostRequestStatus = SmsPostRequestStatus.PhoneNumberEmpty});
            }
            if (string.IsNullOrEmpty(reuqest.Message))
            {
                return Json(new SmsResponseModel { SmsPostRequestStatus = SmsPostRequestStatus.MessageEmpty });
            }
            
            var result = await _smsService.SendSms(new SmsModel
            {
                Message = reuqest.Message,
                PhoneNumber = reuqest.PhoneNumber,
                PhoneOperator = PhoneOperator.Twilio
            });
            return Json(new {result});
        }
    }
}
