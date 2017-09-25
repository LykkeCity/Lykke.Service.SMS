using System;

namespace Lykke.Service.SMS.Client
{
    public class SmsResponseModel
    {
        public SmsPostRequestStatus SmsPostRequestStatus { get; set; }
        public Guid? SmsPostId { get; set; }
    }
}