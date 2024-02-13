namespace StephenCleary.Ch02AsyncBasic.T01PauseForASpecifiedPeriodOfTime
{
    internal class Solution01
    {
        internal static async Task RunAsync(string[] args)
        {
            Task<int> task = DelayResult<int>(99, TimeSpan.FromSeconds(5));
            int result = await task;

            Console.WriteLine(result);
        }

        static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }
    }
}
