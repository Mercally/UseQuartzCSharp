using Quartz;
using Quartz.Impl;
using QuartzNetFramework.Quartz.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzNetFramework.Quartz
{
    public class JobSchedule
    {
        public static void Start()
        {
            IJobDetail ExampleJobBuild = JobBuilder.Create<ExampleJob>()
                .WithIdentity("ExampleJob")
                .Build();

            ITrigger Trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                (s =>
                    s.WithIntervalInSeconds(30)
                    .OnEveryDay()
                    )
                    .ForJob(ExampleJobBuild)
                    .WithIdentity("TriggerExampleJob")
                    .StartNow()
                    .WithCronSchedule("0 0 8 * * ?")
                    .Build();

            ISchedulerFactory SF = new StdSchedulerFactory();
            IScheduler Scheduler = SF.GetScheduler();
            Scheduler.ScheduleJob(ExampleJobBuild, Trigger);
            Scheduler.Start();
        }
    }
}