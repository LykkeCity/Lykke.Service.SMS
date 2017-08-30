using System;
using Common.Log;

namespace Lykke.Service.SMS.Client
{
    public class SMSClient : ISMSClient, IDisposable
    {
        private readonly ILog _log;

        public SMSClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
