﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.SMS.Services
{
    public class SmsRequestModel
    {
        public string PartnerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
