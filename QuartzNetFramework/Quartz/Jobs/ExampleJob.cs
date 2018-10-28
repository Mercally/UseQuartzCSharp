using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuartzNetFramework.Quartz.Jobs
{
    public class ExampleJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            // Hacer algo
        }
    }
}