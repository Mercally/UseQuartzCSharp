using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using QuartzNetCore2.Quartz.Jobs;

namespace QuartzNetCore2
{
    public class Program
    {
        private static IScheduler _scheduler; // add this field

        public static void Main(string[] args)
        {
            StartScheduler();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void StartScheduler()
        {
            var Job = JobBuilder.Create<ExampleJob>()
                .WithIdentity("JobExampleJob")
                .Build();

            var Trigger = TriggerBuilder.Create()
                .WithIdentity("TriggerExampleJob")
                .StartNow()
                .WithCronSchedule("0 15 18 ? * *")
                .Build();

            var SchedulerFactory = new StdSchedulerFactory();
            _scheduler = SchedulerFactory.GetScheduler().Result;
            _scheduler.ScheduleJob(Job, Trigger);
            _scheduler.Start().Wait();
        }
    }
}
