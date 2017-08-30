namespace Lykke.Service.SMS.Core
{
    public class AppSettings
    {
        public SMSSettings SMSService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }

    public class SMSSettings
    {
        public DbSettings Db { get; set; }
    }

    public class DbSettings
    {
        public string LogsConnString { get; set; }
    }

    public class SlackNotificationsSettings
    {
        public AzureQueueSettings AzureQueue { get; set; }
    }

    public class AzureQueueSettings
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}
