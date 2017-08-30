namespace Lykke.Job.SMS.Core
{
    public class AppSettings
    {
        public SMSSettings SMSJob { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }

        public class SMSSettings
        {
            public DbSettings Db { get; set; }
            public string TriggerQueueConnectionString { get; set; }
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
}