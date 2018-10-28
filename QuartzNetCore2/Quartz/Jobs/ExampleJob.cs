using Quartz;
using QuartzNetCore2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzNetCore2.Quartz.Jobs
{
    public class ExampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            IMyCustomService service = new MyCustomService();

            return service.Run();
        }
    }
}
