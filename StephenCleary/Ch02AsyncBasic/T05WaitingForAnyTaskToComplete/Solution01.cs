namespace StephenCleary.Ch02AsyncBasic.T05WaitingForAnyTaskToComplete
{
    internal class Solution01
    {
        internal static async Task RunAsync(string[] args)
        {
            HttpClient client = new();
            //var urlA = "https://mail.ru";
            var urlA = "https://Yandex.ru";
            //var urlB = "https://microsoft.com";
            var urlB = "https://google.com";

            var result = await FirstRespondingUrlAsync(client, urlA, urlB);

            Console.WriteLine(result);
        }

        // Возвращает длину данных первого ответившего URL-адреса.
        static async Task<int> FirstRespondingUrlAsync(HttpClient client,
        string urlA, string urlB)
        {
            // Запустить обе загрузки параллельно.
            Task<byte[]> downloadTaskA = client.GetByteArrayAsync(urlA);
            await Console.Out.WriteLineAsync($"downloadTaskA: {downloadTaskA.Id} uri: {urlA}");

            Task<byte[]> downloadTaskB = client.GetByteArrayAsync(urlB);
            await Console.Out.WriteLineAsync($"downloadTaskA: {downloadTaskB.Id} uri: {urlB}");

            // Ожидать завершения любой из этих задач.
            Task<byte[]> completedTask = await Task.WhenAny(downloadTaskA, downloadTaskB); // await !!!
            Console.WriteLine($"completedTask: {completedTask.Id}");

            // Вернуть длину данных, загруженных по этому URL-адресу.
            byte[] data = await completedTask; // await !!!
            return data.Length;
        }
    }
}
