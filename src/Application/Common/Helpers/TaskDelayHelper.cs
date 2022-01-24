using System;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public static class TaskDelayHelper
    {
        public static async Task Delay()
        {
            var rand = new Random();
            await Task.Delay(rand.Next(500, 2000));
        }
    }
}
