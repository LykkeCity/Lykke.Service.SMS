using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Job.SMS.Core.Domain;

namespace Lykke.Service.SMS.Core.Domain
{
    public interface ISmsResponseModel
    {
        SmsPostRequestStatus SmsPostRequestStatus { get; set; }
        Guid? SmsPostId { get; set; }
    }
}
