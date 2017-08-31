using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Core;
using Lykke.Job.SMS.Core.Domain;

namespace Lykke.Service.SMS.Services
{
    public class SmsModel : ISmsModel
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public PhoneOperator PhoneOperator { get; set; }
    }
}
