using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephenCleary.Ch02AsyncBasic.T02ReturningCompletedTasks
{
    internal class Solution01
    {
        internal static async Task RunAsync(string[] args)
        {
            var myVar = new MySynchronousImplementation();
            Task task = myVar.DoSomethingAsync();
            await task;

        }
    }
    interface IMyAsyncInterface
    {
        Task DoSomethingAsync();
    }

    class MySynchronousImplementation : IMyAsyncInterface
    {
        public Task DoSomethingAsync()
        {
            try
            {
                DoSomethingSynchronously();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        private void DoSomethingSynchronously()
        {
            Console.WriteLine(1 + 2);
        }
    }
}
