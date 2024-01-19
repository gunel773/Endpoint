

using System.Text.Json;
using ThreadTaskAwaitSync.Domain.Models;

namespace ThreadTaskAwaitSync.Helpers.Utilities
{
    public class Helper
    {
        public async Task<List<JsonUsers>> GetDataHttp(Predicate<JsonUsers> filter)
        {
            HttpClient client = new();
            string url = "https://jsonplaceholder.typicode.com/posts";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                List<JsonUsers> userList = JsonSerializer.Deserialize<List<JsonUsers>>(responseData);
                var newUsersList = userList.FindAll(filter);
                string filePath = @"C:\Users\Honor MagicBook\Downloads\ThreadTaskAwaitSync\test.txt";
                string jsonResult = JsonSerializer.Serialize(newUsersList, new JsonSerializerOptions { WriteIndented = true });
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(jsonResult);
                }
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string fileContent = streamReader.ReadToEnd();
                    Console.WriteLine(fileContent);
                }
                return newUsersList;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
        }
    }
}
