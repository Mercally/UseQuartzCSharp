using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzNetCore2.Services
{
    public class MyCustomService : IMyCustomService
    {
        public async Task Run()
        {
            byte Num1 = 1, Num2 = 2;
            int Total = Num1 + Num2;
        }
    }
}
