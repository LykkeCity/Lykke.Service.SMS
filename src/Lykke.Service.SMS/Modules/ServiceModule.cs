using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureStorage.Tables;
using Common.Log;
using Lykke.AzureRepositories;
using Lykke.AzureRepositories.Log;
using Lykke.Core;
using Lykke.Service.SMS.Core;
using Lykke.Service.SMS.Core.Services;
using Lykke.Service.SMS.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.SMS.Modules
{
    public class ServiceModule : Module
    {
        private readonly SMSSettings _settings;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;

        public ServiceModule(SMSSettings settings, ILog log)
        {
            _settings = settings;
            _log = log;

            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_settings)
                .SingleInstance();

            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

           

            Lykke.Core.Log.ILog log = new CommonLogAdapter(_log);
            var smsRepository = new SmsServiceRepository(new AzureRepositories.Azure.Tables.AzureTableStorage<SmsEntity>(_settings.Db.SmsConnString, "SmsServiceRequests", log), log);
            builder.RegisterInstance(smsRepository)
                .As<ISmsServiceRepository>()
                .SingleInstance();

            var traderRepository = new TraderRepository(new AzureRepositories.Azure.Tables.AzureTableStorage<TableEntity>(_settings.Db.TraderConnectionString, "Traders", log),
                    new AzureRepositories.Azure.Tables.AzureTableStorage<TraderSettings>(_settings.Db.TraderConnectionString, "TraderSettings", log));
            builder.RegisterInstance(traderRepository)
                .As<ITraderRepository>()
                .SingleInstance();

            builder.RegisterType<SmsService>()
                .As<ISmsService>()
                .SingleInstance();

            builder.Populate(_services);
        }
    }
}
