using Ch02_T02 = StephenCleary.Ch02AsyncBasic.T02ReturningCompletedTasks;
using Ch02_T03 = StephenCleary.Ch02AsyncBasic.T03TransmittingInformationAboutTheProgressOfAnOperation;
using Ch02_T04 = StephenCleary.Ch02AsyncBasic.T04WaitingForATaskGroupToComplete;
using Ch02_T05 = StephenCleary.Ch02AsyncBasic.T05WaitingForAnyTaskToComplete;

namespace StephenCleary
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            await Ch02_T05.Solution01.RunAsync(args);

            //Task completed1 = Task.CompletedTask;
            //var cts = new CancellationTokenSource();
            //Task completed2 = Task.FromCanceled(cts.Token);
            //Task completed3 = Task.FromException(new ApplicationException("My Exception"));
            //Task completed4 = Task.FromResult<int>(99);
        }
    }
}
