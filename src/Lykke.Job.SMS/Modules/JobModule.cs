﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Log;
using Lykke.Job.SMS.Core;
using Lykke.Job.SMS.Core.Services;
using Lykke.Job.SMS.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Job.SMS.Modules
{
    public class JobModule : Module
    {
        private readonly AppSettings.SMSSettings _settings;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;

        public JobModule(AppSettings.SMSSettings settings, ILog log)
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
                .SingleInstance()
                .WithParameter(TypedParameter.From(TimeSpan.FromSeconds(30)));

            // NOTE: Service registrations example:

            builder.RegisterType<MyFooService>()
                .As<IMyFooService>();

            builder.RegisterType<MyBooService>()
                .As<IMyBooService>();

            // NOTE: You can implement your own poison queue notifier. See https://github.com/LykkeCity/JobTriggers/blob/master/readme.md
            // builder.Register<PoisionQueueNotifierImplementation>().As<IPoisionQueueNotifier>();

            // TODO: Add your dependencies here

            builder.Populate(_services);
        }
    }
}