namespace StephenCleary.Ch02AsyncBasic.T01PauseForASpecifiedPeriodOfTime
{
    internal class Solution02
    {
        internal static async Task RunAsync(string[] args)
        {
            Task<string> task = DownloadStringWithRetries(new HttpClient(), "uri");
            string result = await task;

            Console.WriteLine(result);
        }
        static async Task<string> DownloadStringWithRetries(HttpClient client, string uri)
        {
            // Повторить попытку через 1 секунду, потом через 2 и через 4 секунды.
            TimeSpan nextDelay = TimeSpan.FromSeconds(1);
            for (int i = 0; i != 3; ++i)
            {
                try
                {
                    return await client.GetStringAsync(uri);
                }
                catch
                {
                }
                await Task.Delay(nextDelay);
                nextDelay = nextDelay + nextDelay;
            }
            // Попробовать в последний раз и разрешить распространение ошибки.
            return await client.GetStringAsync(uri);
        }
    }
}
