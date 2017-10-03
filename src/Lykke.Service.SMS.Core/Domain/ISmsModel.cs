using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Core;

namespace Lykke.Job.SMS.Core.Domain
{
    public interface ISmsModel
    {
        string PartnerId { get; set; }
        string PhoneNumber { get; set; }
        string Message { get; set; }
        PhoneOperator PhoneOperator { get; set; }
    }
}
