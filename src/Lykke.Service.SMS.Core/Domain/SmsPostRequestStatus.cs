using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Job.SMS.Core.Domain
{
    public enum SmsPostRequestStatus
    {
        Ok,
        Error,
        PhoneNumberEmpty,
        MessageEmpty
    }
}
