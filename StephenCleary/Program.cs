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
            
        }
    }
}
