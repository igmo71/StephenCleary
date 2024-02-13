using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace StephenCleary.Ch02AsyncBasic.T04WaitingForATaskGroupToComplete
{
    internal class Solution01
    {
        internal static async Task RunAsync(string[] args)
        {
            var urls = new List<string>()
            {
                "?$format=json&$top=10000&$skip=0&$select=Ref_Key,Description",
                "?$format=json&$top=10000&$skip=10000&$select=Ref_Key,Description",
                "?$format=json&$top=10000&$skip=20000&$select=Ref_Key,Description"
            };

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://1c.dobroga.ru/dobroga/odata/standard.odata/Catalog_Номенклатура")
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("DobrogaService:140520")));
            var result = await DownloadAllAsync(httpClient, urls);
            await Console.Out.WriteLineAsync(result);
        }


        static async Task<string> DownloadAllAsync(HttpClient client, IEnumerable<string> urls)
        {
            // Определить действие, выполняемое для каждого URL.
            var downloads = urls.Select(url => client.GetStringAsync(url));
            // Обратите внимание: задачи еще не запущены, потому что последовательность не была обработана.

            // Запустить загрузку для всех URL одновременно.
            Task<string>[] downloadTasks = downloads.ToArray();
            // Все задачи запущены.

            // Асинхронно ожидать завершения всех загрузок.
            string[] htmlPages = await Task.WhenAll(downloadTasks);
            return string.Concat(htmlPages);
        }
    }
}
