﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Lykke.Job.SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"SMS version {Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion}");
#if DEBUG
            Console.WriteLine("Is DEBUG");
#else
            Console.WriteLine("Is RELEASE");
#endif

            var webHost = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            webHost.Run();

            Console.WriteLine("Terminated");
        }
    }
}