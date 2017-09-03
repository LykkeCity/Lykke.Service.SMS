using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Job.SMS.Core.Domain;
using Lykke.Service.SMS.Core.Domain;

namespace Lykke.Service.SMS.Services
{
    public class SmsResponseModel: ISmsResponseModel
    {
        public SmsPostRequestStatus SmsPostRequestStatus { get; set; }
        public Guid? SmsPostId { get; set; }
    }
}
