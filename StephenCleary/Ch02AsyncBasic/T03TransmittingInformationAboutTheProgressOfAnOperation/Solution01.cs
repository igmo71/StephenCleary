namespace StephenCleary.Ch02AsyncBasic.T03TransmittingInformationAboutTheProgressOfAnOperation
{
    internal class Solution01
    {
        internal static async Task RunAsync(string[] args)
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
            {
                Console.Write($"Complete: {args}% \r");
            };
            Task task = MyMethodAsync(progress);
            await task;
            Console.WriteLine("Complete: Done!");
        }

        static async Task MyMethodAsync(IProgress<double>? progress = null)
        {
            bool done = false;
            double persentComplete = 0;
            while (!done)
            {
                await Task.Delay(100);
                persentComplete++;
                
                progress?.Report(persentComplete);

                if (persentComplete == 100)
                    done = true;
            }
        }
    }
}
