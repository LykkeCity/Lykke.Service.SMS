using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Job.SMS.Core.Domain;

namespace Lykke.Service.SMS.Core.Services
{
    public interface ISmsService
    {
        SmsPostRequestStatus SendSms(ISmsModel sms);
    }
}
