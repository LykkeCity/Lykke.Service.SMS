using System;
using Lykke.Service.SMS.Client;
using Lykke.Service.SMS.Client.AutorestClient.Models;

namespace Lykke.Service.Sms.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SMSClient("http://13.93.41.3:1070", null);
            var result = client.SendSms(new SmsRequestModel { Message = "Test message", PhoneNumber = "+79312600505" });
        }
    }
}
