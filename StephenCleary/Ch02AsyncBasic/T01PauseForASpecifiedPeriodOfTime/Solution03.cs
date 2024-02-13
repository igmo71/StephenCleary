namespace StephenCleary.Ch02AsyncBasic.T01PauseForASpecifiedPeriodOfTime
{
    internal class Solution03
    {
        internal static async Task RunAsync(string[] args)
        {
            Task<string> task = DownloadStringWithTimeout(new HttpClient(), "uri");
            string result = await task;

            Console.WriteLine(result);
        }
        static async Task<string> DownloadStringWithTimeout(HttpClient client, string uri)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));
            Task<string> downloadTask = client.GetStringAsync("https://habr.com/ru/companies/jugru/articles/573904/");
            Task timeoutTask = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
            Task completedTask = await Task.WhenAny(downloadTask, timeoutTask);
            if (completedTask == timeoutTask)
                return null;
            return await downloadTask;
        }
    }
}
